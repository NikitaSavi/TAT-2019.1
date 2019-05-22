using System;
using System.Runtime.Serialization;

namespace DEV_10
{
    /// <summary>
    /// Contains warehouse data.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Warehouse : IShopEntity
    {
        /// <summary>
        /// ID of the product.
        /// </summary>
        private int id;

        /// <summary>
        /// Name of the warehouse.
        /// </summary>
        private string name;

        /// <summary>
        /// ID of warehouse address.
        /// </summary>
        private int addressId;

        /// <summary>
        /// Gets or sets the ID.
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
        /// Gets or sets the warehouse name.
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
        /// Gets or sets the address ID.
        /// </summary>
        [DataMember]
        public int AddressId
        {
            get => this.addressId;
            set
            {
                if (this.addressId != value)
                {
                    this.addressId = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <inheritdoc />
        public event Action<IShopEntity> EntityChanged;

        /// <inheritdoc />
        public void ShowInfoToConsole()
        {
            Console.WriteLine($"ID {this.Id}: {this.Name}, {this.AddressId}\n");
        }
    }
}