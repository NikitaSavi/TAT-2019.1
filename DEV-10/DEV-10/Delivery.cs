using System;
using System.Runtime.Serialization;

namespace DEV_10
{
    /// <summary>
    /// Contains delivery data.
    /// </summary>
    [DataContract]
    [Serializable]
    public class Delivery : IShopEntity
    {
        /// <summary>
        /// ID of the product.
        /// </summary>
        private int id;

        /// <summary>
        /// Description of the delivery.
        /// </summary>
        private string description;

        /// <summary>
        /// Date of the delivery in "DD/MM/YYYY" format
        /// </summary>
        private string date;

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
        /// Gets or sets the date.
        /// </summary>
        [DataMember]
        public string Date
        {
            get => this.date;
            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    this.EntityChanged?.Invoke(this);
                }
            }
        }

        /// <inheritdoc />
        public event Action<IShopEntity> EntityChanged;

        /// <inheritdoc />
        public void ShowInfoToConsole()
        {
            Console.WriteLine($"ID {this.Id}: {this.Description}\nDate: {this.Date}\n");
        }
    }
}