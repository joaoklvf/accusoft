using Accusoft.Data;
using Accusoft.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Accusoft.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AccusoftContext _accusoftContext;

        public IndexModel(ILogger<IndexModel> logger, AccusoftContext accusoftContext)
        {
            _logger = logger;
            _accusoftContext = accusoftContext;
        }

        public IList<NotaEmitida>? NotasEmitidas { get; set; }

        public async Task OnGetAsync()
        {
            NotasEmitidas = await _accusoftContext.NotaEmitida
                .Include(n => n.StatusNota)
                .Include(n => n.Credor)
                .ToListAsync();
        }
    }
}
