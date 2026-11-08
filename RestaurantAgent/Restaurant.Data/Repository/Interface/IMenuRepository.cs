using Restaurant.Domain;

namespace Restaurant.Data.Repository.Interface
{
    public interface IMenuRepository
    {
        IEnumerable<MenuItem> GetAllMenuItems();

        IEnumerable<MenuItem> GetMenuItemsByName(string name);

        IEnumerable<MenuItem> GetAllVegetarianItems();

        IEnumerable<MenuItem> GetAllVeganItems();

        IEnumerable<MenuItem> GetAllSpicyItems();

        IEnumerable<MenuItem> GetAllSpicyVegetarianItems();

        MenuItem? GetMenuItemByExactName(string name);

        void AddMenuItem(MenuItem menuItem);
    }
}
