using ePortfolio.Models;
using ePortfolio.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePortfolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController(JsonFileProjectsService projectsService) =>
              ProjectsService = projectsService;

        public JsonFileProjectsService ProjectsService { get; }

        [HttpGet]
        public IEnumerable<Project> Get() 
        {
            Console.WriteLine("Gotten Service");
            return ProjectsService.GetProducts();
        }
    }
}
