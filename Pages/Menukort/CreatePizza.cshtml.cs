using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaWebsite.Pages.Menukort
{
    public class CreatePizzaModel : PageModel
    {
        [BindProperty]
        public Pizza currentPizza { get; set; }
        private PizzaService _pizzaService;

        public CreatePizzaModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            _pizzaService.AddPizza(currentPizza);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
