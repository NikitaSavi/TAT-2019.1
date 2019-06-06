using System;

namespace CW_9.WriterFactory
{
    /// <summary>
    /// Selects the required writer by entered command.
    /// </summary>
    public class WriterSelector
    {
        /// <summary>
        /// Gets the required writer.
        /// </summary>
        /// <param name="name">
        /// Name of the file
        /// </param>
        /// <returns>
        /// The required writer.
        /// </returns>
        public IWriter GetWriter(string name)
        {
            switch (name.Split('.')[1])
            {
                case "json":
                    return new JsonWriter(name);
                case "xml":
                    return new XmlWriter(name);
                default:
                    throw new Exception("File extension is not supported.");
            }
        }
    }
}
