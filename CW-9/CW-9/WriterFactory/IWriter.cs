using System.Collections.Generic;

namespace CW_9.WriterFactory
{
    /// <summary>
    /// Defines a serializer.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Path to the file.
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// Serializes a list to a file.
        /// </summary>
        /// <param name="currencies">
        /// List to serialize.
        /// </param>
        void Write(List<Currency> currencies);
    }
}
