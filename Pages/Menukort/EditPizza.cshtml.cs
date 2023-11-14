using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaWebsite.Pages.Menukort
{
    public class EditPizzaModel : PageModel
    {
        [BindProperty]
        public Pizza currentPizza { get; set; }
        PizzaService _pizzaService;

        public EditPizzaModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult OnGet(int id)
        {
            currentPizza = _pizzaService.GetPizza(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            _pizzaService.UpdatePizza(currentPizza);
            return RedirectToPage("Index");
        }
    }
}
