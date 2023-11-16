using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaWebsite.Pages.Menukort
{
    public class DeletePizzaModel : PageModel
    {
        [BindProperty]
        public Pizza CurrentPizza { get; set; }
        PizzaService _pizzaService;

        public DeletePizzaModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult OnGet(int id)
        {
            CurrentPizza = _pizzaService.GetPizza(id);
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            _pizzaService.DeletePizza(id);
            return RedirectToPage("Index");
        }
    }
}
