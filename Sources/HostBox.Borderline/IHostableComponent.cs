namespace HostBox.Borderline
{
    /// <summary>
    /// Hostable component interface.
    /// </summary>
    public interface IHostableComponent
    {
        /// <summary>
        /// Starts component.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops component.
        /// </summary>
        void Stop();

        /// <summary>
        /// Pauses component.
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes component.
        /// </summary>
        void Resume();
    }
}