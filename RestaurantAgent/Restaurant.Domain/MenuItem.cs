namespace Restaurant.Domain
{
    public class MenuItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsVegetarian { get; set; }

        public bool IsVegan { get; set; }

        public bool IsSpicy { get; set; }

        public List<string> Ingredients { get; set; } = [];

        public string RecommendedDrink { get; set; } = string.Empty;

        public List<string> ComboSuggestions { get; set; } = [];
    }
}
