namespace LibraryManagement.Book.Application.Contracts.Queries.GetBook
{
    public class GetBookQueryResponse
    {
		public int Id { get; set; }
		public string Name { get; set; } = default!;
		public int Stock { get; set; }
		public string Category { get; set; } = default!;
		public float Price { get; set; }
		public int Year { get; set; }
		public int AuthorId { get; set; }
    }
}