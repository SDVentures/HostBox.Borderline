using System.Threading;
using System.Threading.Tasks;

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
        Task Start(CancellationToken cancellationToken);

        /// <summary>
        /// Stops component.
        /// </summary>
        Task Stop(CancellationToken cancellationToken);
    }
}
