#r "packages/FAKE/tools/FakeLib.dll" // include Fake lib
open Fake
open Fake.AssemblyInfoFile

open System
open System.IO

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

let project = "HostBox.Borderline"
let authors = ["SDVentures Team"]
let summary = "A library declares the plugin interface to load into HostBox."
let description = """
  The package contains plugin interfaces."""
let license = "MIT License"
let tags = "hostbox plugin host"

let release = ReleaseNotesHelper.parseReleaseNotes (File.ReadLines "RELEASE_NOTES.md")

let buildDir = @"build\"
let nugetDir = @"nuget\"

let projects =
    !! "Sources/**/*.csproj"

let isAppVeyorBuild = environVar "APPVEYOR" <> null
let appVeyorBuildNumber = environVar "APPVEYOR_BUILD_NUMBER"
let appVeyorRepoCommit = environVar "APPVEYOR_REPO_COMMIT"


Target "CleanUp" (fun _ ->
    CleanDirs [ buildDir ]
)

Target "BuildVersion" (fun _ ->
    let buildVersion = sprintf "%s-build%s" release.NugetVersion appVeyorBuildNumber
    Shell.Exec("appveyor", sprintf "UpdateBuild -Version \"%s\"" buildVersion) |> ignore
)

Target "AssemblyInfo" (fun _ ->
    printfn "%A" release
    let info =
        [ Attribute.Title project
          Attribute.Product project
          Attribute.Description summary
          Attribute.Version release.AssemblyVersion
          Attribute.FileVersion release.AssemblyVersion
          Attribute.InformationalVersion release.NugetVersion
          Attribute.Copyright license ]
    CreateCSharpAssemblyInfo <| "./Sources/" @@ project @@ "/Properties/AssemblyInfo.cs" <| info
)

Target "Build" (fun () ->
    MSBuildRelease buildDir "Build" projects |> Log "Build Target Output: "
)

Target "Deploy" (fun () ->
    NuGet (fun p ->
        { p with
            Authors = authors
            Project = project
            Summary = summary
            Description = description
            Version = release.NugetVersion
            ReleaseNotes = toLines release.Notes
            Tags = tags
            OutputPath = buildDir
            ToolPath = "./packages/NuGet.CommandLine/tools/Nuget.exe"
            AccessKey = getBuildParamOrDefault "nugetkey" ""
            Publish = hasBuildParam "nugetkey"
            Dependencies =
                [ ]
            Files =
                [ (@"..\" +  buildDir + "HostBox.Borderline.dll", Some "lib/net452", None) ]})
        <| (nugetDir + project + ".nuspec")
)

"CleanUp"
    =?> ("BuildVersion", isAppVeyorBuild)
    ==> "AssemblyInfo"
    ==> "Build"
    ==> "Deploy"

RunTargetOrDefault "Deploy"
