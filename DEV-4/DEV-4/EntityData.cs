namespace DEV_4
{
    /// <summary>
    /// Class for containing general information of entities (GUID and Description)
    /// </summary>
    class EntityData
    {
        public string EntityGuid { get; set; }
        public string Description { get; set; }
        private const int DescriptionMaxLength = 256;

        public EntityData(string description = null)
        {
            this.Description = description.WithMaxLength(DescriptionMaxLength);
            EntityGuid = EntityGuid.GenerateGuid();
        }
    }
}
