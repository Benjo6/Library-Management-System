namespace LibraryManagement.Book.Application.Contracts.Commands.CreateBook
{
    public record CreateBookCommand
    {
        public string Name { get; init; } = default!;
        public int Stock { get; init; }
        public float Price { get; init; }
        public string Category { get; init; } = default!;
        public int Year { get; init; }
        public int AuthorId { get; init; }
    }
}