namespace DEV_4
{
    class EntityData
    {
        public string EntityGuid { get; }
        public string Description { get; }
        private const int DescriptionMaxLength = 250;

        public EntityData(string description = null)
        {
            Description = description.WithMaxLength(DescriptionMaxLength);
            EntityGuid = EntityGuid.GenerateGuid();
        }
    }
}
