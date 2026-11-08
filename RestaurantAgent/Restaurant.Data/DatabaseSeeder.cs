using LiteDB;
using Restaurant.Domain;

namespace Restaurant.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(LiteDatabase db)
        {
            var menuItems = db.GetCollection<MenuItem>("menuitems");

            if (menuItems.Count() > 0)
                return;

            menuItems.InsertBulk(new[]
            {
        new MenuItem
        {
            Id = 1,
            Name = "Paneer Tikka",
            Category = "Starter",
            Price = 8.99m,
            Description = "Grilled cottage cheese cubes marinated in spices.",
            IsVegetarian = true,
            IsVegan = false,
            IsSpicy = true,
            Ingredients = ["Paneer", "Onion", "Capsicum", "Yogurt", "Spices"],
            RecommendedDrink = "Mango Lassi",
            ComboSuggestions = ["Butter Naan", "Paneer Butter Masala"]
        },

        new MenuItem
        {
            Id = 2,
            Name = "Veg Spring Rolls",
            Category = "Starter",
            Price = 6.99m,
            Description = "Crispy rolls stuffed with vegetables.",
            IsVegetarian = true,
            IsVegan = true,
            IsSpicy = false,
            Ingredients = ["Cabbage", "Carrot", "Spring Roll Wrapper"],
            RecommendedDrink = "Fresh Lime Soda",
            ComboSuggestions = ["Veg Fried Rice"]
        },

        new MenuItem
        {
            Id = 3,
            Name = "Chicken 65",
            Category = "Starter",
            Price = 9.99m,
            Description = "Deep fried spicy chicken bites.",
            IsVegetarian = false,
            IsVegan = false,
            IsSpicy = true,
            Ingredients = ["Chicken", "Chili", "Curry Leaves"],
            RecommendedDrink = "Cola",
            ComboSuggestions = ["Chicken Biryani"]
        },

        new MenuItem
        {
            Id = 4,
            Name = "Gobi Manchurian",
            Category = "Starter",
            Price = 7.99m,
            Description = "Cauliflower tossed in spicy Manchurian sauce.",
            IsVegetarian = true,
            IsVegan = true,
            IsSpicy = true,
            Ingredients = ["Cauliflower", "Spring Onion", "Soy Sauce"],
            RecommendedDrink = "Fresh Lime Soda",
            ComboSuggestions = ["Veg Fried Rice"]
        },

        new MenuItem
        {
            Id = 5,
            Name = "Butter Chicken",
            Category = "Main Course",
            Price = 14.99m,
            Description = "Chicken cooked in rich buttery tomato gravy.",
            IsVegetarian = false,
            IsVegan = false,
            IsSpicy = false,
            Ingredients = ["Chicken", "Butter", "Cream", "Tomato"],
            RecommendedDrink = "Sweet Lassi",
            ComboSuggestions = ["Butter Naan"]
        },

        new MenuItem
        {
            Id = 6,
            Name = "Chicken Biryani",
            Category = "Main Course",
            Price = 15.99m,
            Description = "Aromatic rice cooked with chicken and spices.",
            IsVegetarian = false,
            IsVegan = false,
            IsSpicy = true,
            Ingredients = ["Chicken", "Basmati Rice", "Onion", "Spices"],
            RecommendedDrink = "Cola",
            ComboSuggestions = ["Raita"]
        },

        new MenuItem
        {
            Id = 7,
            Name = "Veg Biryani",
            Category = "Main Course",
            Price = 13.99m,
            Description = "Aromatic rice cooked with fresh vegetables.",
            IsVegetarian = true,
            IsVegan = true,
            IsSpicy = true,
            Ingredients = ["Rice", "Carrot", "Beans", "Peas", "Spices"],
            RecommendedDrink = "Mint Lemonade",
            ComboSuggestions = ["Raita"]
        },

        new MenuItem
        {
            Id = 8,
            Name = "Paneer Butter Masala",
            Category = "Main Course",
            Price = 13.49m,
            Description = "Paneer cubes cooked in creamy tomato gravy.",
            IsVegetarian = true,
            IsVegan = false,
            IsSpicy = false,
            Ingredients = ["Paneer", "Butter", "Cream", "Tomato"],
            RecommendedDrink = "Mango Lassi",
            ComboSuggestions = ["Garlic Naan"]
        },

        new MenuItem
        {
            Id = 9,
            Name = "Chana Masala",
            Category = "Main Course",
            Price = 11.99m,
            Description = "Chickpeas cooked with Indian spices.",
            IsVegetarian = true,
            IsVegan = true,
            IsSpicy = true,
            Ingredients = ["Chickpeas", "Tomato", "Onion", "Spices"],
            RecommendedDrink = "Fresh Lime Soda",
            ComboSuggestions = ["Jeera Rice"]
        },

        new MenuItem
        {
            Id = 10,
            Name = "Masala Dosa",
            Category = "South Indian",
            Price = 9.99m,
            Description = "Crispy rice crepe stuffed with potato masala.",
            IsVegetarian = true,
            IsVegan = false,
            IsSpicy = true,
            Ingredients = ["Rice Batter", "Potato", "Mustard Seeds"],
            RecommendedDrink = "Filter Coffee",
            ComboSuggestions = ["Medu Vada"]
        },

        new MenuItem
        {
            Id = 11,
            Name = "Idli Sambar",
            Category = "South Indian",
            Price = 8.49m,
            Description = "Steamed rice cakes served with sambar.",
            IsVegetarian = true,
            IsVegan = true,
            IsSpicy = false,
            Ingredients = ["Rice", "Lentils", "Sambar"],
            RecommendedDrink = "Filter Coffee",
            ComboSuggestions = ["Medu Vada"]
        },

        new MenuItem
        {
            Id = 12,
            Name = "Veg Fried Rice",
            Category = "Rice & Noodles",
            Price = 10.99m,
            Description = "Stir-fried rice with vegetables.",
            IsVegetarian = true,
            IsVegan = true,
            IsSpicy = false,
            Ingredients = ["Rice", "Carrot", "Peas", "Beans"],
            RecommendedDrink = "Lemon Soda",
            ComboSuggestions = ["Gobi Manchurian"]
        },

        new MenuItem
        {
            Id = 13,
            Name = "Chicken Fried Rice",
            Category = "Rice & Noodles",
            Price = 12.99m,
            Description = "Stir-fried rice with chicken.",
            IsVegetarian = false,
            IsVegan = false,
            IsSpicy = false,
            Ingredients = ["Rice", "Chicken", "Egg", "Soy Sauce"],
            RecommendedDrink = "Cola",
            ComboSuggestions = ["Chicken 65"]
        },

        new MenuItem
        {
            Id = 14,
            Name = "Hakka Noodles",
            Category = "Rice & Noodles",
            Price = 10.49m,
            Description = "Indo-Chinese stir fried noodles.",
            IsVegetarian = true,
            IsVegan = true,
            IsSpicy = true,
            Ingredients = ["Noodles", "Cabbage", "Carrot", "Soy Sauce"],
            RecommendedDrink = "Fresh Lime Soda",
            ComboSuggestions = ["Veg Spring Rolls"]
        },

        new MenuItem
        {
            Id = 15,
            Name = "Gulab Jamun",
            Category = "Dessert",
            Price = 4.99m,
            Description = "Milk-solid dumplings soaked in sugar syrup.",
            IsVegetarian = true,
            IsVegan = false,
            IsSpicy = false,
            Ingredients = ["Milk Solids", "Sugar", "Cardamom"],
            RecommendedDrink = "Filter Coffee",
            ComboSuggestions = ["Mango Lassi"]
        },

        new MenuItem
        {
            Id = 16,
            Name = "Rasmalai",
            Category = "Dessert",
            Price = 5.99m,
            Description = "Soft cottage cheese patties in sweet milk.",
            IsVegetarian = true,
            IsVegan = false,
            IsSpicy = false,
            Ingredients = ["Paneer", "Milk", "Sugar"],
            RecommendedDrink = "Mango Lassi",
            ComboSuggestions = ["Filter Coffee"]
        },

        new MenuItem
        {
            Id = 17,
            Name = "Mango Lassi",
            Category = "Beverage",
            Price = 3.99m,
            Description = "Refreshing mango yogurt drink.",
            IsVegetarian = true,
            IsVegan = false,
            IsSpicy = false,
            Ingredients = ["Mango", "Yogurt", "Sugar"],
            RecommendedDrink = "",
            ComboSuggestions = []
        },

        new MenuItem
        {
            Id = 18,
            Name = "Fresh Lime Soda",
            Category = "Beverage",
            Price = 2.99m,
            Description = "Fresh squeezed lime with soda water.",
            IsVegetarian = true,
            IsVegan = true,
            IsSpicy = false,
            Ingredients = ["Lime", "Soda Water", "Sugar"],
            RecommendedDrink = "",
            ComboSuggestions = []
        }
    });
        }
    }
}

