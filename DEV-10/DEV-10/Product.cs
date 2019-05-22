using System;
using System.Runtime.Serialization;

namespace DEV_10
{
    /// <summary>
    /// Contains products data.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Product : IShopEntity
    {
        /// <summary>
        /// ID of the product.
        /// </summary>
        private int id;

        /// <summary>
        /// Description of the product.
        /// </summary>
        private string description;

        /// <summary>
        /// Quantity of the product.
        /// </summary>
        private int quantity;

        /// <summary>
        /// Manufacturer ID.
        /// </summary>
        private int manufacturerId;

        /// <summary>
        /// Warehouse ID.
        /// </summary>
        private int warehouseId;

        /// <summary>
        /// Delivery ID.
        /// </summary>
        private int deliveryId;

        /// <summary>
        /// Date of manufacture in "DD.MM.YYYY" format.
        /// </summary>
        private string manufactureDate;

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
        /// Gets or sets the description.
        /// </summary>
        [DataMember]
        public string Description
        {
            get => this.description;
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        [DataMember]
        public int Quantity
        {
            get => this.quantity;
            set
            {
                if (this.quantity != value)
                {
                    this.quantity = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the manufacturer id.
        /// </summary>
        [DataMember]
        public int ManufacturerId
        {
            get => this.manufacturerId;
            set
            {
                if (this.manufacturerId != value)
                {
                    this.manufacturerId = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the warehouse ID.
        /// </summary>
        [DataMember]
        public int WarehouseId
        {
            get => this.warehouseId;
            set
            {
                if (this.warehouseId != value)
                {
                    this.warehouseId = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the delivery ID.
        /// </summary>
        [DataMember]
        public int DeliveryId
        {
            get => this.deliveryId;
            set
            {
                if (this.deliveryId != value)
                {
                    this.deliveryId = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the manufacture date.
        /// </summary>
        [DataMember]
        public string ManufactureDate
        {
            get => this.manufactureDate;
            set
            {
                if (this.manufactureDate != value)
                {
                    this.manufactureDate = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <inheritdoc />
        public event Action<IShopEntity> EntityChanged;

        /// <inheritdoc />
        public void ShowInfoToConsole()
        {
            Console.WriteLine(
                $"ID {this.Id}: {this.Description}\n{this.Quantity} in store\nManufacturerID: {this.ManufacturerId}\n"
                + $"WarehouseID: {this.WarehouseId}\nDeliveryID: {this.DeliveryId}\nManufacture date: {ManufactureDate}\n");
        }
    }
}