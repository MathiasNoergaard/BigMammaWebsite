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

        [BindProperty]
        public Topping.Toppings topping { get; set; }
        public List<Topping.Toppings> toppingList { get; set; } = new();

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

        public IActionResult OnPostAddTopping()
        {
            //make the below persistent somehow
            toppingList.Add(topping); 
            return Page();
        }

        public IActionResult OnPostRemoveTopping(int posid)
        {
            Console.WriteLine(posid);
            Console.WriteLine(toppingList.Count);
            if(posid < toppingList.Count)
            {
                toppingList.RemoveAt(posid);
            }
            return Page();
        }
    }
}
