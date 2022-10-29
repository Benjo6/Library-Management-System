using AutoMapper;
using LibraryManagement.Author.Application.Contracts.Commands.CreateAuthor;
using LibraryManagement.Author.Application.Contracts.Commands.RemoveAuthor;
using LibraryManagement.Author.Application.Contracts.Queries.GetAuthor;
using LibraryManagement.Protobuf;

namespace LibraryManagement.Author.Service
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<GetAuthorRequest,GetAuthorQuery>();
            CreateMap<GetAuthorQueryResponse,GetAuthorResponse>();
            CreateMap<AddAuthorRequest,CreateAuthorCommand>();
            CreateMap<CreateAuthorCommandResponse,AddAuthorResponse>();
            CreateMap<RemoveAuthorRequest,RemoveAuthorCommand>();
            CreateMap<RemoveAuthorCommandResponse,RemoveAuthorResponse>();

        }
        
    }
}