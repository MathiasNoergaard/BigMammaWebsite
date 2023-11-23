using BigMammaWebsite.Models;
using System.Text.Json;

namespace BigMammaWebsite.Service
{
    public class JsonFileUserService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName { get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Users.Json"); } }

        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public void SaveJsonUsers(List<User> users)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<User[]>(jsonWriter, users.ToArray());
            }
        }

        public IEnumerable<User> GetJsonUsers()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<User[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
