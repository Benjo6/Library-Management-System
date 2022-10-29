using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagement.Author.Application.Contracts.Commands.CreateAuthor;
using LibraryManagement.Author.Application.Contracts.Commands.RemoveAuthor;
using LibraryManagement.Author.Application.Contracts.Queries.GetAllAuthors;
using LibraryManagement.Author.Application.Contracts.Queries.GetAuthor;
using LibraryManagement.Author.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Author.Application
{
    public class AuthorApplicationService : IAuthorApplicationService
    {
        private readonly AuthorDbContext _authorDbContext;
        private readonly IMapper _mapper;

        public AuthorApplicationService(AuthorDbContext authorDbContext, IMapper mapper)
        {
            _authorDbContext = authorDbContext;
            _mapper = mapper;
        }

        public async Task<CreateAuthorCommandResponse> AddAuthorAsync(CreateAuthorCommand request)
        {
            var author = new Domain.Author
            {
                Name = request.Name
            };
            await _authorDbContext.Authors.AddAsync(author);
            await _authorDbContext.SaveChangesAsync();

            return new CreateAuthorCommandResponse
            {
                Id = author.Id
            };
        }

        public async Task<List<GetAuthorQueryResponse>> GetAllAuthorAsync(GetAllAuthorsQuery query)
        {
            var authors = await _authorDbContext.Authors
                .AsNoTracking()
                .ProjectTo<GetAuthorQueryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return authors;
        }

        public async Task<GetAuthorQueryResponse> GetAuthorAsync(GetAuthorQuery query)
        {
            var author = await _authorDbContext.Authors.AsNoTracking().ProjectTo<GetAuthorQueryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == query.Id);

            return author;
        }

        public async Task<RemoveAuthorCommandResponse> RemoveAuthor(RemoveAuthorCommand request)
        {
            var author = await _authorDbContext.Authors.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(author is not null)
            {
                _authorDbContext.Entry(author).State = EntityState.Deleted;
                await _authorDbContext.SaveChangesAsync();
                return new RemoveAuthorCommandResponse
                {
                    Deleted = true
                };
            }

            return new RemoveAuthorCommandResponse
            {
                Deleted = false
            };
        }
    }
}