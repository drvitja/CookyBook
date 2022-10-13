namespace CookyBook.Shared.DataTransferObjects
{
    public class RecipeDto : DtoBase
    {
        public bool Selected { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Preparation { get; set; }

        public TimeSpan? Duration { get; set; }

        public string? Level { get; set; }   

        public string? ImageUrl { get; set; }
    }
}
