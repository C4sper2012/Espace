using Espace.Service.Shared.Contracts;
using Espace.Service.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Espace.RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        #region Fields

        private readonly ITodoService _service;
        private readonly ILogger<IndexModel> _logger;

        #endregion

        [BindProperty(SupportsGet = true)]
        public List<TodoItem> TodoItems { get; set; } = new();
        
        
        public IndexModel(ITodoService service, ILogger<IndexModel> logger)
        {
            _service = service;
            _logger = logger;
        }

        // ReSharper disable once UnusedMember.Global
        public async Task<IActionResult> OnGetAsync()
        {
            TodoItems = await _service.GetItemsAsync();
            return Page();
        }
        
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            await _service.Delete(id);
            return Page();
        }
    }
}