namespace LibraryManagement.Book.Application.Contracts.Commands.CreateBook
{
    public record CreateBookCommand
    {
        public string Name { get; init; } = default!;
        public int Stock { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public int AuthorId { get; init; }
    }
}