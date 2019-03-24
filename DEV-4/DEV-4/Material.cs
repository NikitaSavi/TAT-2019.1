namespace DEV_4
{
    abstract class Material
    {
        private readonly EntityData _data;

        protected Material(string name, string description = null)
        {
            _data = new EntityData(name, description);
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(_data.Description) ? "No description" : _data.Description;
        }

        public bool Equals(Material obj)
        {
            return _data.EntityGuid.Equals(obj._data.EntityGuid);
        }
    }
}