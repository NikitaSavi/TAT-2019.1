namespace DEV_4
{
    abstract class Material
    {
        private readonly EntityData Data;

        protected Material(string name, string description)
        {
            Data = new EntityData(name, description);
        }
        public override string ToString()
        {
            return string.IsNullOrEmpty(Data.Description) ? "No description" : Data.Description;
        }

        public bool Equals(Material obj)
        {
            return Data.Guid.Equals(obj.Data.Guid);
        }
    }
}