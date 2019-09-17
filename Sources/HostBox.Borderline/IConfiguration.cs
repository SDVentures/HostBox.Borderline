using System;
using System.Collections.Generic;

namespace HostBox.Borderline
{
    /// <summary>
    /// Component configuration interface.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Configuration key.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Configuration path.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Configuration value.
        /// </summary>
        string Value { get; }

        /// <summary>Gets a configuration value.</summary>
        /// <param name="key">The configuration key.</param>
        /// <returns>The configuration value.</returns>
        string this[string key] { get; }

        /// <summary>
        /// Binds configuration section to the instance of specified type.
        /// </summary>
        /// <typeparam name="T">Type to bind.</typeparam>
        /// <param name="path">Configuration section path.</param>
        /// <returns>Binded instance.</returns>
        T BindSection<T>(string path) where T : new();

        /// <summary>
        /// Returns nested configuration objects.
        /// </summary>
        /// <returns>Nested configuration objects.</returns>
        IEnumerable<IConfiguration> GetChildren();

        /// <summary>
        /// Returns configuration subsection by specified path.
        /// </summary>
        /// <param name="path">Path of a subsection to return.</param>
        /// <returns>The <see cref="IConfiguration" />.</returns>
        IEnumerable<IConfiguration> GetSection(string path);

        /// <summary>
        /// Registers configuration reload callback.
        /// </summary>
        /// <param name="callback">Callback to register.</param>
        void OnReload(Action<IConfiguration> callback);
    }
}