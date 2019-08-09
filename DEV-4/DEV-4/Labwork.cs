namespace DEV_4
{
    /// <summary>
    /// Class for labworks
    /// </summary>
    public class Labwork : Material
    {
        /// <summary>
        /// Constructor for labworks
        /// </summary>
        /// <param name="description">Description, null by default</param>
        public Labwork(string description = null)
            : base(description)
        {
        }

        /// <inheritdoc />
        public override object Clone() =>
            new Labwork
                {
                    Data = { Description = Data.Description, EntityGuid = Data.EntityGuid }
                };
    }
}
