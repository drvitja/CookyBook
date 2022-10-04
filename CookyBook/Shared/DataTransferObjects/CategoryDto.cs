namespace CookyBook.Shared.DataTransferObjects
{
    public class CategoryDto : DtoBase
    {
        public bool Selected { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

    }
}
