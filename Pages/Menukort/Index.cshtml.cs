using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BigMammaWebsite.Pages.Menukort
{
    public class MenuKortModel : PageModel
    {
        public string Message;
        private PizzaService _pizzaService;
        public List<Pizza> pizzas { get; set; }

        public MenuKortModel(PizzaService pizzaService) //Dependency Injection
        {
            _pizzaService = pizzaService;
        }

        public void OnGet()
        {
            pizzas = _pizzaService.GetItems(); ;
        }

        [BindProperty]
        public string ToppingFilter { get; set; }

        [BindProperty]
        public string NameFilter { get; set; }

        [BindProperty]
        public int PriceFilterMin { get; set; }

        [BindProperty]
        public int PriceFilterMax { get; set; }

        public IActionResult OnPostFilter()
        {
            pizzas.ElementAt(0).GetHashCode();
            Console.WriteLine("orks");
            if (String.IsNullOrEmpty(ToppingFilter))
            {
                pizzas = _pizzaService.GetItems();
            }
            else
            {
                pizzas = _pizzaService.FilterTopping(ToppingFilter);
            }
            return Page();
        }

        public IActionResult OnPostReset()
        {
            ToppingFilter = string.Empty;
            ModelState.Clear();
            pizzas = _pizzaService.GetItems();
            return Page();
        }
    }
}
