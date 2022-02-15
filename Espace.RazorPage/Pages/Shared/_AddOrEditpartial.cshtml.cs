using Espace.Service.Helpers;
using Espace.Service.Shared.Contracts;
using Espace.Service.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Espace.RazorPage.Pages.Shared
{
    public class _AddOrEditpartial : PageModel
    {
        private ITodoService _service;

        [BindProperty(SupportsGet = true)]
        public TodoItem TodoItem { get; set; } = new();
        
        public _AddOrEditpartial(ITodoService service)
        {
            _service = service;
        }

        public async Task OnGet(int id)
        {
            await _service.GetItemByIdAsync(id);
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _service.GetItemByIdAsync(id);
            return RedirectToPage(AppConstants.BaseUrl);
        }
    }
}