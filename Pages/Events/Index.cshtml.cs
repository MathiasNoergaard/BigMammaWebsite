using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaWebsite.Pages.Events
{
    public class IndexModel : PageModel
    {
        private ItemService _itemService;
        public List<Event> events { get; set; }

        public IndexModel(ItemService itemService) //Dependency Injection
        {
            _itemService = itemService;
        }

        public void OnGet()
        {
            events = _itemService.GetItems(); ;
        }
    }
}
