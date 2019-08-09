using System;
using System.Runtime.Serialization;

namespace CW_9
{
    /// <summary>
    /// The currency data.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Currency
    {
        /// <summary>
        /// Name of the currency.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Rate of the currency to BYN.
        /// </summary>
        [DataMember]
        public string Rate { get; set; }

        /// <summary>
        /// Initializes a new empty instance of the <see cref="Currency"/> class.
        /// </summary>
        public Currency()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="name">
        /// Name of the currency.
        /// </param>
        /// <param name="rate">
        /// Rate of the currency to BYN.
        /// </param>
        public Currency(string name, string rate)
        {
            this.Name = name;
            this.Rate = rate;
        }
    }
}