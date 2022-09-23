namespace DataAccess.Entities
{
    public class CookRecipe : EntityBase
    {
        public string? Name { get; set; }

        public string? ShortDescription { get; set; }

        public TimeSpan Time { get; set; }
    }
}