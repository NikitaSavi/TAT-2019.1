namespace DEV_4
{
    class EntityData
    {
        public string EntityGuid { get; set; }
        public string Description { get; set; }
        private const int DescriptionMaxLength = 250;

        public EntityData(string description = null)
        {
            Description = description.WithMaxLength(DescriptionMaxLength);
            EntityGuid = StringExtension.GenerateGuid();
        }
    }
}
