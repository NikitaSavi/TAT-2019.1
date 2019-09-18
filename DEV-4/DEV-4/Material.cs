using System;

namespace DEV_4
{
    /// <summary>
    /// Parent class for all materials
    /// </summary>
    public abstract class Material : ICloneable
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public EntityData Data { get; set; }

        /// <summary>
        /// Base constructor for materials, sets general data
        /// </summary>
        /// <param name="description">Description of an entity, null by default</param>
        protected Material(string description = null)
        {
            this.Data = new EntityData(description);
        }

        /// <summary>
        /// Override method to return description of an entity
        /// </summary>
        /// <returns>Description of an entity</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(this.Data.Description)
                ? "No description available"
                : $"Description: {Data.Description}";
        }

        /// <summary>
        /// Override method for comparing entities. Entities are equal if their GUIDs are equal
        /// </summary>
        /// <param name="obj">An entity to check equality with</param>
        /// <returns>True if received entity has the same GUID</returns>
        public override bool Equals(object obj)
        {
            return obj is Material material && this.Data.EntityGuid == material.Data.EntityGuid;
        }

        /// <summary>
        /// Performs deep cloning of an entity
        /// </summary>
        /// <returns>A clone of an entity</returns>
        public virtual object Clone()
        {
            throw new NotImplementedException();
        }
    }
}