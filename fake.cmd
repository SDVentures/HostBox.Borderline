@echo off
rem SET PATH=%LOCALAPPDATA%\Microsoft\dotnet;%PATH%
@echo on
dotnet restore dotnet-fake.csproj
dotnet fake %*
