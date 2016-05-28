namespace HostBox.Borderline
{
    /// <summary>
    /// Компонент приложения <c>AppHoster</c>.
    /// Компонент должен уметь работать как <c>Windows</c> служба.
    /// </summary>
    public interface IHostableComponent
    {
        /// <summary>
        /// Запустить компонент.
        /// </summary>
        void Start();

        /// <summary>
        /// Остановить компонент.
        /// </summary>
        void Stop();

        /// <summary>
        /// Приостановить компонент.
        /// </summary>
        void Pause();

        /// <summary>
        /// Возобновить работу компонента.
        /// </summary>
        void Resume();
    }
}
