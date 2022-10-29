using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using LibraryManagement.Protobuf;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    public class BookController : GrpcControllerBase<Book.BookClient>
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await Service.GetAllBooksAsync(new Empty());
           
            return Ok(response.GetBookResponse);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await Service.GetBookAsync(new GetBookRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBookRequest request)
        {
            var response =  await Service.AddBookAsync(request);
            return Ok(response);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(RemoveBookRequest request)
        {
            var response = await Service.RemoveBookAsync(request);
            return Ok(response);
        }
        [HttpGet("suggest/{id}")]
        public async Task<IActionResult> SuggestBook(int id)
        {
            var response = await Service.GetSuggestedBooksAsync(new SuggestedBooksRequest { Id = id });
            return Ok(response);
        }



    }
}
