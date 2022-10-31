using AutoMapper;
using LibraryManagement.Book.Application.Contracts.Queries.GetBook;
using LibraryManagement.Book.Application.Contracts.Queries.GetSuggestedBooks;

namespace LibraryManagement.Book.Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Domain.Book, GetBookQueryResponse>();
            CreateMap<Domain.Book, GetSuggestedBooksQueryResponse>();
        }
    }
}