using System.Reflection;

namespace HostBox.Borderline
{
    public interface IAssemblyLoader
    {
        Assembly Load(AssemblyName name);

        Assembly LoadDefault();
    }
}
