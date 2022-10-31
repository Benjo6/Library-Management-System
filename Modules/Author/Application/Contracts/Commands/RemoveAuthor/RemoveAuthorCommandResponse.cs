using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Author.Application.Contracts.Commands.RemoveAuthor
{
    public class RemoveAuthorCommandResponse
    {
        public bool Deleted { get; set; }
    }
}
