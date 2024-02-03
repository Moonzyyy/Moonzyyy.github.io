using ePortfolio.Models;
using System.Text.Json;

namespace ePortfolio.Services
{
    public class JsonFileProjectsService
    {
        public JsonFileProjectsService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "projects.json");

        public IEnumerable<Project> GetProducts()
        {
            try
            {
                using var jsonFileReader = File.OpenText(JsonFileName);
                return JsonSerializer.Deserialize<Project[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    })!;
            }
            catch (Exception e) 
            {
                Console.WriteLine("Error: No Projects Found?");
                Console.Write(e.ToString());
                return new Project[0];
            }
        }
    }
}
