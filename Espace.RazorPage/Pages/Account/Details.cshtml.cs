using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Espace.RazorPage.Pages.Account
{
    [Authorize]
    public class Details : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}