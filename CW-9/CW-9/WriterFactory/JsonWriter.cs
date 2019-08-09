using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CW_9.WriterFactory
{
    /// <summary>
    /// Handles serialization to JSON file.
    /// </summary>
    public class JsonWriter : IWriter
    {
        /// <inheritdoc />
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonWriter"/> class.
        /// </summary>
        /// <param name="name">
        /// Name of the file.
        /// </param>
        public JsonWriter(string name)
        {
            this.Path = $"../../../{name}";
        }

        /// <inheritdoc />
        public void Write(List<Currency> currencies)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Currency>));
            using (var fileStream = new FileStream(this.Path, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fileStream, currencies);
            }
        }
    }
}
