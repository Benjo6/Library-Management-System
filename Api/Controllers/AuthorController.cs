using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using LibraryManagement.Protobuf;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    public class AuthorController : GrpcControllerBase<Author.AuthorClient>
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await Service.GetAllAuthorsAsync(new Empty());
           
            return Ok(response.GetAuthorResponse);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await Service.GetAuthorAsync(new GetAuthorRequest() { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddAuthorRequest request)
        {
            var response =  await Service.AddAuthorAsync(request);
            return Ok(response);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(RemoveAuthorRequest request)
        {
            var response = await Service.RemoveAuthorAsync(request);
            return Ok(response);
        }
    }
}