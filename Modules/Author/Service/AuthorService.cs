using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using LibraryManagement.Author.Application;
using LibraryManagement.Author.Application.Contracts.Commands.CreateAuthor;
using LibraryManagement.Author.Application.Contracts.Commands.RemoveAuthor;
using LibraryManagement.Author.Application.Contracts.Queries.GetAllAuthors;
using LibraryManagement.Author.Application.Contracts.Queries.GetAuthor;
using LibraryManagement.Author.Infrastructure;
using LibraryManagement.Protobuf;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Author.Service
{
    public class AuthorService : Protobuf.Author.AuthorBase
    {
        private readonly IAuthorApplicationService _authorApplicationService;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorApplicationService authorApplicationService,IMapper mapper)
        {
            _authorApplicationService = authorApplicationService;
            _mapper = mapper;
        }

        public override async Task<GetAuthorResponse> GetAuthor(GetAuthorRequest request, ServerCallContext context)
        {
            var response = await _authorApplicationService.GetAuthorAsync(_mapper.Map<GetAuthorQuery>(request));
            return _mapper.Map<GetAuthorResponse>(response);
        }

        public override async Task<GetAllAuthorsResponse> GetAllAuthors(Empty request, ServerCallContext context)
        {
            var response = await _authorApplicationService.GetAllAuthorAsync(new GetAllAuthorsQuery());
            return new GetAllAuthorsResponse
            {
                GetAuthorResponse = { _mapper.Map<List<GetAuthorQueryResponse>, List<GetAuthorResponse>>(response) }
            };
        }

        

        public override async Task<AddAuthorResponse> AddAuthor(AddAuthorRequest request, ServerCallContext context)
        {
            var response = await _authorApplicationService.AddAuthorAsync(_mapper.Map<CreateAuthorCommand>(request));
            return _mapper.Map<AddAuthorResponse>(response);
        }

        public override async Task<RemoveAuthorResponse> RemoveAuthor(RemoveAuthorRequest request, ServerCallContext context)
        {
            var response = await _authorApplicationService.RemoveAuthor(_mapper.Map<RemoveAuthorCommand>(request));
            return _mapper.Map<RemoveAuthorResponse>(response);
        }

    }
}