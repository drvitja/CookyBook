namespace CookyBook.Shared.DataTransferObjects
{
    public class CookRecipeDto : DtoBase
    {
        public bool Selected { get; set; }

        public string? Name { get; set; }

        public string? ShortDescription { get; set; }

        public TimeSpan Time { get; set; } 
    }
}
