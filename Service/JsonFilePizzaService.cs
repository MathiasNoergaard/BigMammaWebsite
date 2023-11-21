using BigMammaWebsite.Models;
using System.Text.Json;

namespace BigMammaWebsite.Service
{
    public class JsonFilePizzaService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName { get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Pizzas.Json"); } }

        public JsonFilePizzaService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public void SaveJsonPizzas(List<Pizza> pizzas)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Pizza[]>(jsonWriter, pizzas.ToArray());
            }
        }

        public IEnumerable<Pizza> GetJsonPizzas()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Pizza[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
