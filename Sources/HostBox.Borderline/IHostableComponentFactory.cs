namespace HostBox.Borderline
{
    /// <summary>
    /// Фабрика создания компонентов.
    /// </summary>
    public interface IHostableComponentFactory
    {
        /// <summary>
        /// Component instance.
        /// </summary>
        /// <param name="loader">Component assembly loader.</param>
        /// <param name="config">Component configuration.</param>
        /// <returns>Component instance.</returns>
        IHostableComponent CreateComponent(IAssemblyLoader loader, IConfiguration config = null);
    }
}