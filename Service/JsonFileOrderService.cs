using BigMammaWebsite.Models;
using System.Text.Json;

namespace BigMammaWebsite.Service
{
    public class JsonFileOrderService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName { get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Orders.Json"); } }

        public JsonFileOrderService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public void SaveJsonOrders(List<Order> orders)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Order[]>(jsonWriter, orders.ToArray());
            }
        }

        public IEnumerable<Order> GetJsonOrders()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Order[]>(jsonFileReader.ReadToEnd());
            }
        }
        public void SaveJsonPizzas(List<Order> orderlist)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Order[]>(jsonWriter, orderlist.ToArray());
            }
        }
    }
}
