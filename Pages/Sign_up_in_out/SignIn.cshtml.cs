using BigMammaWebsite.Models;
using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaWebsite.Pages.Sign_up_in_out
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        private UserService userService { get; set; }
        public static int sessionID { get; set; } = -1;

        public SignInModel(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!userService.AttemptLogin(user))
                return Page();
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Index");
        }
    }
}
