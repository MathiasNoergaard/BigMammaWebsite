using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BigMammaWebsite.Models;
using BigMammaWebsite.Service;

namespace BigMammaWebsite.Pages.Sign_up_in_out
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        private UserService userService { get; set; }

        public IndexModel(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!userService.AddUser(user))
                return Page();
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Index");
        }
    }
}
