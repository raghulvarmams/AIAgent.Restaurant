using LiteDB;
using Restaurant.Data.Repository.Interface;
using Restaurant.Domain;

namespace Restaurant.Data.Repository.Service
{
    public class MenuRepository : IMenuRepository
    {
        private readonly LiteDatabase _database;
        private readonly ILiteCollection<MenuItem> _menuItems;

        public MenuRepository(RestaurantDatabase restaurantDatabase)
        {
            _database = restaurantDatabase.Database;
            _menuItems = _database.GetCollection<MenuItem>("menuitems");
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItems.Insert(menuItem);
        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return _menuItems.FindAll();
        }

        public IEnumerable<MenuItem> GetAllVegetarianItems()
        {
            return _menuItems.Find(f => f.IsVegetarian);
        }

        public IEnumerable<MenuItem> GetMenuItemsByName(string name)
        {
            return _menuItems.Find(x => x.Name.Contains(name));
        }

        public IEnumerable<MenuItem> GetAllVeganItems()
        {
            return _menuItems.Find(f => f.IsVegan);
        }

        public IEnumerable<MenuItem> GetAllSpicyItems()
        {
            return _menuItems.Find(f => f.IsSpicy);
        }

        public IEnumerable<MenuItem> GetAllSpicyVegetarianItems()
        {
            return _menuItems.Find(f => f.IsVegetarian && f.IsSpicy);
        }

        public MenuItem? GetMenuItemByExactName(string name)
        {
            return _menuItems.Find(f => f.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
    }
}
