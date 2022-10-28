
namespace LibraryManagement.Book.Application.Contracts.Queries.GetSuggestedBooks
{
    public class GetSuggestedBooksQueryResponse
    {
        public string Name { get; set; } = default!;
        public int AuthorId { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Category { get; set; } = default!;
    }
}