using ImobiliariaLM.RazorPages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ImobiliariaLM.RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace ImobiliariaLM.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Contexto _contexto;

        public IndexModel(Contexto contexto, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _contexto = contexto;
        }

        public List<CadastroModel> Dados { get; set; }

        public async Task OnGet()
        {
            Dados = await _contexto.Cadastro.ToListAsync();
        }
    }
}