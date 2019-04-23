namespace DEV_6
{
    /// <summary>
    /// Struct for car information.
    /// </summary>
    internal struct CarInfoStruct
    {
        /// <summary>
        /// Mark of the car.
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// Model of the mark.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Quantity of cars of this model.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price of an individual car
        /// </summary>
        public int Price { get; set; }
    }
}