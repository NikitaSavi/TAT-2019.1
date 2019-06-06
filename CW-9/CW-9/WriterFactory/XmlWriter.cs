using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CW_9.WriterFactory
{
    /// <summary>
    /// Handles serialization to XML file.
    /// </summary>
    public class XmlWriter : IWriter
    {
        /// <inheritdoc />
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlWriter"/> class.
        /// </summary>
        /// <param name="name">
        /// Name of the file.
        /// </param>
        public XmlWriter(string name)
        {
            this.Path = $"../../../{name}";
        }

        /// <inheritdoc />
        public void Write(List<Currency> currencies)
        {
            var xmlFormatter = new XmlSerializer(typeof(List<Currency>));
            using (var fileStream = new FileStream(this.Path, FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fileStream, currencies);
            }
        }
    }
}
