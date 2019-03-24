namespace DEV_4
{
    class EntityData
    {
        public string Name { get; set; }
        public string EntityGuid { get; set; }
        public string Description { get; set; }
        private const int DescriptionMaxLength = 250;

        public EntityData(string name, string description = null)
        {
            Name = name;
            Description = description.WithMaxLength(DescriptionMaxLength);
            EntityGuid = StringExtension.GenerateGuid();
        }   
    }
}
