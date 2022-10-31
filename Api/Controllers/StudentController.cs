using Google.Protobuf.WellKnownTypes;
using Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Api.Controllers
{

    public class StudentController : GrpcControllerBase<Students.StudentsClient>
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await Service.GetAllStudentsAsync(new empty {});

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await Service.GetStudentByIdAsync(new StudentID { Id=id});
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateStudentRequest request)
        {
            var response = await Service.CreateStudentAsync(new CreateStudentRequest { Firstname=request.Firstname,Lastname=request.Lastname,Balance=request.Balance});
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Service.DeleteStudentAsync(new StudentID { Id=id});
            return Ok(response);
        }
    }
}
