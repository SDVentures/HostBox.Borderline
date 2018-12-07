namespace HostBox.Borderline
{
    /// <summary>
    /// Фабрика создания компонентов.
    /// </summary>
    public interface IHostableComponentFactory
    {
        /// <summary>
        /// Создает экземпляр компонента.
        /// </summary>
        /// <returns>Экземпляр компонента.</returns>
        IHostableComponent CreateComponent();
    }
}