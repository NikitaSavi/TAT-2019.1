using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

//// TODO Figure out what methods are supposed to be implemented and how
namespace DEV_10
{
    /// <summary>
    /// The shop.
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// The products list.
        /// </summary>
        public List<Product> ProductsList { get; set; }

        /// <summary>
        /// The manufacturers list.
        /// </summary>
        public List<Manufacturer> ManufacturersList { get; set; }

        /// <summary>
        /// The warehouses list.
        /// </summary>
        public List<Warehouse> WarehousesList { get; set; }

        /// <summary>
        /// The deliveries list.
        /// </summary>
        public List<Delivery> DeliveriesList { get; set; }

        /// <summary>
        /// The addresses list.
        /// </summary>
        public List<Address> AddressesList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shop"/> class.
        /// </summary>
        public Shop()
        {
            this.ProductsList = new List<Product>();
            this.ManufacturersList = new List<Manufacturer>();
            this.WarehousesList = new List<Warehouse>();
            this.DeliveriesList = new List<Delivery>();
            this.AddressesList = new List<Address>();
        }

        /// <summary>
        /// Adds a new database entity to the appropriate list.
        /// </summary>
        /// <param name="databaseEntity">
        /// The database entity.
        /// </param>
        public void AddNewEntity(IShopEntity databaseEntity)
        {
            switch (databaseEntity)
            {
                case Product product:
                    this.ProductsList.Add(product);
                    break;
                case Manufacturer manufacturer:
                    this.ManufacturersList.Add(manufacturer);
                    break;
                case Warehouse warehouse:
                    this.WarehousesList.Add(warehouse);
                    break;
                case Delivery delivery:
                    this.DeliveriesList.Add(delivery);
                    break;
                case Address address:
                    this.AddressesList.Add(address);
                    break;
            }
        }

        //// TODO Remake
        
        /// <summary>
        /// Deletes an entity from the appropriate list.
        /// </summary>
        /// <param name="databaseEntity">
        /// The database entity.
        /// </param>
        public void DeleteEntity(IShopEntity databaseEntity)
        {
            switch (databaseEntity)
            {
                case Product product:
                    this.ProductsList.Remove(product);
                    break;
                case Manufacturer manufacturer:
                    this.ManufacturersList.Remove(manufacturer);
                    break;
                case Warehouse warehouse:
                    this.WarehousesList.Remove(warehouse);
                    break;
                case Delivery delivery:
                    this.DeliveriesList.Remove(delivery);
                    break;
                case Address address:
                    this.AddressesList.Remove(address);
                    break;
            }
        }

        /// <summary>
        /// Reads JSON database.
        /// </summary>
        public void ReadDatabase()
        {
            DataContractJsonSerializer jsonFormatter;
            using (var fs = new FileStream("../../Database/products.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
                this.ProductsList = (List<Product>)jsonFormatter.ReadObject(fs);
                foreach (var item in this.ProductsList)
                {
                    item.EntityChanged += this.UpdateJsonDatabase;
                }
            }

            using (var fs = new FileStream("../../Database/manufacturers.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Manufacturer>));
                this.ManufacturersList = (List<Manufacturer>)jsonFormatter.ReadObject(fs);
                foreach (var item in this.ManufacturersList)
                {
                    item.EntityChanged += this.UpdateJsonDatabase;
                }
            }

            using (var fs = new FileStream("../../Database/warehouses.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Warehouse>));
                this.WarehousesList = (List<Warehouse>)jsonFormatter.ReadObject(fs);
                foreach (var item in this.WarehousesList)
                {
                    item.EntityChanged += this.UpdateJsonDatabase;
                }
            }

            using (var fs = new FileStream("../../Database/deliveries.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Delivery>));
                this.DeliveriesList = (List<Delivery>)jsonFormatter.ReadObject(fs);
                foreach (var item in this.DeliveriesList)
                {
                    item.EntityChanged += this.UpdateJsonDatabase;
                }
            }

            using (var fs = new FileStream("../../Database/addresses.json", FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
                this.AddressesList = (List<Address>)jsonFormatter.ReadObject(fs);
                foreach (var item in this.AddressesList)
                {
                    item.EntityChanged += this.UpdateJsonDatabase;
                }
            }
        }

        /// <summary>
        /// Updates the appropriate JSON data file.
        /// </summary>
        /// <param name="databaseEntity">
        /// The database entity.
        /// </param>
        public void UpdateJsonDatabase(IShopEntity databaseEntity)
        {
            DataContractJsonSerializer jsonFormatter;
            switch (databaseEntity)
            {
                case Product _:
                    using (var fs = new FileStream("../../Database/products.json", FileMode.OpenOrCreate))
                    {
                        jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
                        jsonFormatter.WriteObject(fs, this.ProductsList);
                    }

                    break;
                case Manufacturer _:
                    using (var fs = new FileStream("../../Database/manufacturers.json", FileMode.OpenOrCreate))
                    {
                        jsonFormatter = new DataContractJsonSerializer(typeof(List<Manufacturer>));
                        jsonFormatter.WriteObject(fs, this.ManufacturersList);
                    }

                    break;
                case Warehouse _:
                    using (var fs = new FileStream("../../Database/warehouses.json", FileMode.OpenOrCreate))
                    {
                        jsonFormatter = new DataContractJsonSerializer(typeof(List<Warehouse>));
                        jsonFormatter.WriteObject(fs, this.WarehousesList);
                    }

                    break;
                case Delivery _:
                    using (var fs = new FileStream("../../Database/deliveries.json", FileMode.OpenOrCreate))
                    {
                        jsonFormatter = new DataContractJsonSerializer(typeof(List<Delivery>));
                        jsonFormatter.WriteObject(fs, this.DeliveriesList);
                    }

                    break;
                case Address _:
                    using (var fs = new FileStream("../../Database/addresses.json", FileMode.OpenOrCreate))
                    {
                        jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
                        jsonFormatter.WriteObject(fs, this.AddressesList);
                    }

                    break;
            }
        }

        /// <summary>
        /// Writes database to XML files.
        /// </summary>
        public void WriteToXml()
        {
            XmlSerializer formatter;
            using (var fs = new FileStream("../../Database/products.xml", FileMode.OpenOrCreate))
            {
                formatter = new XmlSerializer(typeof(List<Product>));
                formatter.Serialize(fs, this.ProductsList);
            }

            using (var fs = new FileStream("../../Database/manufacturers.xml", FileMode.OpenOrCreate))
            {
                formatter = new XmlSerializer(typeof(List<Manufacturer>));
                formatter.Serialize(fs, this.ManufacturersList);
            }

            using (var fs = new FileStream("../../Database/warehouses.xml", FileMode.OpenOrCreate))
            {
                formatter = new XmlSerializer(typeof(List<Warehouse>));
                formatter.Serialize(fs, this.WarehousesList);
            }

            using (var fs = new FileStream("../../Database/deliveries.xml", FileMode.OpenOrCreate))
            {
                formatter = new XmlSerializer(typeof(List<Delivery>));
                formatter.Serialize(fs, this.DeliveriesList);
            }

            using (var fs = new FileStream("../../Database/addresses.xml", FileMode.OpenOrCreate))
            {
                formatter = new XmlSerializer(typeof(List<Address>));
                formatter.Serialize(fs, this.AddressesList);
            }
        }

        //// TODO Remake

        /// <summary>
        /// Outputs info to console.
        /// </summary>
        public void ShowInfoToConsole()
        {
            Console.WriteLine("Enter what to display:");
            switch (Console.ReadLine())
            {
                case "product":
                    foreach (var product in this.ProductsList)
                    {
                        product.ShowInfoToConsole();
                    }

                    break;
                case "manufacturer":
                    foreach (var manufacturer in this.ManufacturersList)
                    {
                        manufacturer.ShowInfoToConsole();
                    }

                    break;
                case "warehouse":
                    foreach (var warehouse in this.WarehousesList)
                    {
                        warehouse.ShowInfoToConsole();
                    }

                    break;
                case "delivery":
                    foreach (var delivery in this.DeliveriesList)
                    {
                        delivery.ShowInfoToConsole();
                    }

                    break;
                case "address":
                    foreach (var address in this.AddressesList)
                    {
                        address.ShowInfoToConsole();
                    }

                    break;
            }
        }
    }
}