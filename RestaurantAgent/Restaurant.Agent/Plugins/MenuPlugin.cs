using Microsoft.SemanticKernel;
using Restaurant.Data.Repository.Interface;
using Restaurant.Domain;
using System.ComponentModel;

namespace Restaurant.Agent.Plugins
{
    public class MenuPlugin
    {
        private readonly IMenuRepository _menuRepository;
        public MenuPlugin(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [KernelFunction]
        [Description("Returns all dishes available in the restaurant menu.")]
        public IEnumerable<MenuItem> GetAllMenuItems() => _menuRepository.GetAllMenuItems();

        [KernelFunction]
        [Description("Returns vegetarian dishes from the restaurant menu. Use this when customers ask for vegetarian foods or meat-free options.")]
        public IEnumerable<MenuItem> GetAllVegetarianItems() => _menuRepository.GetAllVegetarianItems();

        [KernelFunction]
        [Description("Returns all vegan menu items. Use this function whenever a customer asks for vegan food, plant-based dishes, dairy-free choices, or vegan recommendations.")]
        public IEnumerable<MenuItem> GetAllVeganItems() => _menuRepository.GetAllVeganItems();
        
        [KernelFunction]
        [Description("Returns all Spicy Menu Items available in the restaurant menu. Use this when customers ask for spicy foods.")]
        public IEnumerable<MenuItem> GetAllSpicyItems() => _menuRepository.GetAllSpicyItems();


        [KernelFunction]
        [Description("Returns all Spicy Vegetarian Menu Items available in the restaurant menu. Use this when customers ask for vegetarian foods or meat-free options and are spicy.")]
        public IEnumerable<MenuItem> GetAllSpicyVegetarianItems() => _menuRepository.GetAllSpicyVegetarianItems();

        [KernelFunction]
        [Description("Returns a single menu item that exactly matches the provided dish name. Use when a customer asks about a specific dish, its ingredients, price, description, or details.")]
        public MenuItem? GetMenuItemByExactName([Description("The exact name of the dish.")] string name) => _menuRepository.GetMenuItemByExactName(name);

        [KernelFunction]
        [Description("Searches the restaurant menu for dishes whose names partially or fully match the provided text. Use when a customer mentions a keyword such as Paneer, Chicken, Biryani, Dosa, Rice, Noodles, or Curry.")]
        public IEnumerable<MenuItem> GetMenuItemsByName([Description("A full or partial dish name to search for.")] string name) => _menuRepository.GetMenuItemsByName(name);

    }
}
