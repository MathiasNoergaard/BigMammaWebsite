using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaWebsite.Pages.Menukort
{
    public class CreatePizzaModel : PageModel
    {
        private PizzaService _pizzaService;

        [BindProperty]
        public Pizza _event { get; set; }

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
            _pizzaService.AddPizza(_event);
            return RedirectToPage("Index");
        }
    }
}
