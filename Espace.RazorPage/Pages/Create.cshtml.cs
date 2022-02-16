using Espace.Service.Helpers;
using Espace.Service.Shared.Contracts;
using Espace.Service.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Espace.RazorPage.Pages
{
    public class CreateModel : PageModel
    {
        private ITodoService _service;

        public CreateModel(ITodoService service)
        {
            _service = service;
        }

        [BindProperty] public TodoItem TodoItem { get; set; } = new();
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(TodoItem);
                return RedirectToPage(AppConstants.BaseUrl);
            }

            return Page();
        }
    }
}