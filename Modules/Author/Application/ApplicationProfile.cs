using AutoMapper;
using LibraryManagement.Author.Application.Contracts.Queries.GetAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Author.Application
{
    public class ApplicationProfile:Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Domain.Author, GetAuthorQueryResponse>();
        }
    }
}
