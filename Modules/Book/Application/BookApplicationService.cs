using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagement.Book.Application.Contracts.Commands.CreateBook;
using LibraryManagement.Book.Application.Contracts.Commands.RemoveBook;
using LibraryManagement.Book.Application.Contracts.Queries.GetAllBooks;
using LibraryManagement.Book.Application.Contracts.Queries.GetBook;
using LibraryManagement.Book.Application.Contracts.Queries.GetSuggestedBooks;
using LibraryManagement.Book.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Book.Application
{
    public class BookApplicationService : IBookApplicationService
    {
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public BookApplicationService(BookDbContext bookDbContext, IMapper mapper)
        {
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<GetBookQueryResponse> GetBookAsync(GetBookQuery bookQuery)
        {
            var book = await _bookDbContext.Books
                .AsNoTracking()
                .ProjectTo<GetBookQueryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == bookQuery.Id);
            
            return book;
        }

        public async Task<List<GetBookQueryResponse>> GetAllBooksAsync(GetAllBooksQuery query)
        {
            var books = await _bookDbContext.Books
                .AsNoTracking()
                .ProjectTo<GetBookQueryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return books;
        }

        public async Task<List<GetSuggestedBooksQueryResponse>> SuggestedBooksAsync(GetSuggestedBooksQuery query)
        {
            var requestedBook = await _bookDbContext.Books
                .AsNoTracking().FirstOrDefaultAsync(x => x.AuthorId == query.Id);
            
            var books = await _bookDbContext.Books.AsNoTracking().ProjectTo<GetSuggestedBooksQueryResponse>(_mapper.ConfigurationProvider).Where(x => x.Category == requestedBook.Category).ToListAsync();

            return books;
        }

        public async Task<CreateBookCommandResponse> AddBookAsync(CreateBookCommand request)
        {
            var book = new Domain.Book
            {
                Name = request.Name,
                Category = request.Category,
                AuthorId = request.AuthorId,
                Year = request.Year,
                Stock = request.Stock,
                Price = request.Price
            };

            await _bookDbContext.Books.AddAsync(book);
            await _bookDbContext.SaveChangesAsync();

            return new CreateBookCommandResponse
            {
                Id = book.Id
            };
        }
        
        public async Task<RemoveBookCommandResponse> RemoveBook(RemoveBookCommand request)
        {
            var book = await _bookDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (book is not null)
            {
                _bookDbContext.Entry(book).State = EntityState.Deleted;
                await _bookDbContext.SaveChangesAsync();
                return new RemoveBookCommandResponse
                {
                    Deleted = true
                };
            }

            return new RemoveBookCommandResponse
            {
                Deleted = false
            };
        }
    }
}