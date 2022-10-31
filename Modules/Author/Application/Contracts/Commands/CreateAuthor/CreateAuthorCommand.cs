using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Author.Application.Contracts.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public string Name { get; init; }
    }
}
