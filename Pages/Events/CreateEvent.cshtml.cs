using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaWebsite.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        private ItemService _itemService;

        [BindProperty]
        public Event _event { get; set; }

        public CreateEventModel(ItemService itemService)
        {
            _itemService = itemService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            _itemService.AddEvent(_event);
            return RedirectToPage("Index");
        }
    }
}
