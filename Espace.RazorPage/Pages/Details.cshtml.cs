using Espace.Service.Helpers;
using Espace.Service.Shared.Contracts;
using Espace.Service.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Espace.RazorPage.Pages
{
    public class DetailsModel : PageModel
    {
        private ITodoService _service;

        public DetailsModel(ITodoService service)
        {
            _service = service;
        }

        [BindProperty] public TodoItem TodoItem { get; set; } = new();

        public async Task OnGetAsync(int id)
        {
            TodoItem = await _service.GetItemByIdAsync(id);
        }
    }
}