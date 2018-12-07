namespace HostBox.Borderline
{
    /// <summary>
    /// Запускаемый компонент.
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