using System;
using System.Runtime.Serialization;

namespace DEV_10
{
    /// <summary>
    /// Contains manufacturers data.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Manufacturer : IShopEntity
    {
        /// <summary>
        /// ID of the product.
        /// </summary>
        private int id;

        /// <summary>
        /// Name of the manufacturer.
        /// </summary>
        private string name;

        /// <summary>
        /// Registration ID.
        /// </summary>
        private int registrationId;

        /// <summary>
        /// Manufacturer's country.
        /// </summary>
        private string country;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember]
        public int Id
        {
            get => this.id;
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name
        {
            get => this.name;
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the registration ID.
        /// </summary>
        [DataMember]
        public int RegistrationId
        {
            get => this.registrationId;
            set
            {
                if (this.registrationId != value)
                {
                    this.registrationId = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [DataMember]
        public string Country
        {
            get => this.country;
            set
            {
                if (this.country != value)
                {
                    this.country = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <inheritdoc />
        public event Action<IShopEntity> EntityChanged;

        /// <inheritdoc />
        public void ShowInfoToConsole()
        {
            Console.WriteLine($"ID {this.Id}: {this.Name}, {this.RegistrationId}, {this.Country}\n");
        }
    }
}