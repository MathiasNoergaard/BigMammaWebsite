using BigMammaWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigMammaWebsite.Pages.Sign_up_in_out
{
    public class LogOutModel : PageModel
    {

        public IActionResult OnGet()
        {
            Service.UserService.SignOut();
            return RedirectToPage("/Index");
        }
    }
}
