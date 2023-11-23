using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaWebsite.Models;
using BigMammaWebsite.Service;

namespace BigMammaWebsite.Pages.Kurv
{
    public class IndexModel : PageModel
    {
        public Order order { get; set; }
        private OrderService _orderService;
        public List<Order> orders { get; set; }

        public IndexModel(OrderService orderService) //Dependency Injection
        {
            _orderService = orderService;
        }

        public void OnGet()
        {
            orders = _orderService.GetOrder();
            order = orders.ElementAt(0);
            Console.WriteLine(order);
        }


    }
}
