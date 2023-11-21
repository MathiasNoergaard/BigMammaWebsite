using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BigMammaWebsite.Pages.Menukort
{
    public class SearchFilterPizzaModel : PageModel
    {
        public List<Pizza> events { get; set; }
        private PizzaService _pizzaService;
        [Required]
        
        [BindProperty]
        public string ToppingFilter { get; set; }

        public SearchFilterPizzaModel(PizzaService pizzaService) //Dependency Injection
        {
            _pizzaService = pizzaService;
        }

        public void OnGet()
        {
            events = _pizzaService.GetItems(); ;
        }

        public IActionResult OnPostFilter()
        {
            if(String.IsNullOrEmpty(ToppingFilter))
            {
                events = _pizzaService.GetItems();
            } else
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
