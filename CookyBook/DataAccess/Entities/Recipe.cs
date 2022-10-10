namespace DataAccess.Entities
{
    public class Recipe : EntityBase
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Preparation { get; set; }

        public TimeSpan Duration { get; set; }

        public string? ImageUrl { get; set; }

        public string? Level { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
}