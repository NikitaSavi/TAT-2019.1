using System;

namespace DEV_10
{
    /// <summary>
    /// The ShopEntity interface.
    /// </summary>
    public interface IShopEntity
    {
        /// <summary>
        /// Notifies that entity was changed and the database document must be updated.
        /// </summary>
        event Action<IShopEntity> EntityChanged;

        /// <summary>
        /// Writes all information to console
        /// </summary>
        void ShowInfoToConsole();
    }
}