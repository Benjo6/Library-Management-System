namespace LibraryManagement.Author.Application.Contracts.Queries.GetAuthor
{
    public class GetAuthorQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
