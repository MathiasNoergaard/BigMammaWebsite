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
        public List<Pizza> events { get; set; }

        public MenuKortModel(PizzaService pizzaService) //Dependency Injection
        {
            _pizzaService = pizzaService;
        }

        public void OnGet()
        {
            events = _pizzaService.GetItems(); ;
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
            Console.WriteLine("orks");
            if (String.IsNullOrEmpty(ToppingFilter))
            {
                events = _pizzaService.GetItems();
            }
            else
            {
                events = _pizzaService.FilterTopping(ToppingFilter);
            }
            return Page();
        }

        public IActionResult OnPostReset()
        {
            ToppingFilter = string.Empty;
            ModelState.Clear();
            events = _pizzaService.GetItems();
            return Page();
        }
    }
}
