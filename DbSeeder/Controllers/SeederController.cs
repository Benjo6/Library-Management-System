using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DatabaseSeeder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeederController : ControllerBase
    {
        private readonly ILogger<SeederController> _logger;
        private readonly Seeder.DbSeeder _seeder;

        public SeederController(ILogger<SeederController> logger, Seeder.DbSeeder seeder)
        {
            _logger = logger;
            _seeder = seeder;
        }

        [HttpGet("SeedData")]
        public Task Seed()
        {
            _seeder.SeedData();
            return Task.CompletedTask;
        }
    }
}
