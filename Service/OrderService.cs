using BigMammaWebsite.Models;
namespace BigMammaWebsite.Service
{
    public class OrderService
    {
        private static List<Order> _orderlist { get; set; } = new();

        private JsonFileOrderService JsonFileOrderService { get; set; }

        public OrderService(JsonFileOrderService jsonFileOrderService)
        {
            JsonFileOrderService = jsonFileOrderService;
            //JsonFilePizzaService.SaveJsonPizzas(_pizzaDictionary.Values.ToList());
            _orderlist = JsonFileOrderService.GetJsonOrders().ToList();
        }
        public List<Order> GetOrder()
        {
            return _orderlist;
        }
    }
}
