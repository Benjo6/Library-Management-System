using LibraryManagement.Author.Application.Contracts.Commands.CreateAuthor;
using LibraryManagement.Author.Application.Contracts.Commands.RemoveAuthor;
using LibraryManagement.Author.Application.Contracts.Queries.GetAllAuthors;
using LibraryManagement.Author.Application.Contracts.Queries.GetAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Author.Application
{
    public interface IAuthorApplicationService
    {
        Task<GetAuthorQueryResponse> GetAuthorAsync(GetAuthorQuery query);
        Task<List<GetAuthorQueryResponse>> GetAllAuthorAsync(GetAllAuthorsQuery query);
        Task<CreateAuthorCommandResponse> AddAuthorAsync(CreateAuthorCommand request);
        Task<RemoveAuthorCommandResponse> RemoveAuthor(RemoveAuthorCommand request);


    }
}
