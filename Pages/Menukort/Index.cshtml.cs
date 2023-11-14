using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaWebsite.Pages.Menukort
{
    public class MenuKortModel : PageModel
    {
        public string Message;
        private PizzaService _pizzaService;
        public List<Pizza> events { get; set; }

        public MenuKortModel(PizzaService pizzaService) //Dependency Injection
        {
            _pizzaService = pizzaService;
        }

        public void OnGet()
        {
            events = _pizzaService.GetItems(); ;
        }
    }
}
