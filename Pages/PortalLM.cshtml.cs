using ImobiliariaLM.RazorPages.Data;
using ImobiliariaLM.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Jarvis.Toolkit;

namespace ImobiliariaLM.RazorPages.Pages;

public class PortalLMModel : PageModel
{
    public CadastroModel Model { get; set; } = new();

    private readonly Contexto _contexto;
    private readonly IWebHostEnvironment env;

    public PortalLMModel(Contexto contexto, IWebHostEnvironment _env)
    {
        _contexto = contexto;
        env = _env;
    }

    public string DivSelecionada { get; set; }

    public void OnGet()
    {
        DivSelecionada = "div0";
    }

    public IActionResult OnGetMostrarDiv(string divId)
    {
        // Atualiza a div selecionada com base no valor passado no parâmetro
        DivSelecionada = divId;
        return Page();
    }

    public async Task<IActionResult> OnPost(CadastroModel Model) 
    {
        if (Model.Imagem.IsNull())
        {
            TempData["Error"] = "Imagem do imóvel não anexado.";
            /*return View();*/
        }

        var nomeArquivoServidor = await Upload(Model.Imagem);

        if (nomeArquivoServidor.IsNullOrEmptyOrWhiteSpace())
        {
            TempData["Error"] = "A Imagem do imóvel não foi enviado.";
            /*return;*/
        }

        Model.NomeImagemImovel = nomeArquivoServidor;

        var cadastroImovel = new CadastroModel()
        {
            Id = Model.Id,
            Titulo = Model.Titulo,
            Descricao = Model.Descricao,
            Valor = Model.Valor,
            VendaAluguel = Model.VendaAluguel,
            CEP = Model.CEP,
            Endereco = Model.Endereco,
            Cidade = Model.Cidade,
            Bairro = Model.Bairro,
            Complemento = Model.Complemento,
            MtQuadrado = Model.MtQuadrado,
            QtdBanheiros = Model.QtdBanheiros,
            QtdQuartos = Model.QtdQuartos,
            QtdVagas = Model.QtdVagas,
            NomeImagemImovel = Model.NomeImagemImovel,
        };

        // Passando a tarefa criada
        await _contexto.Cadastro.AddAsync(cadastroImovel);
        // Salvando
        await _contexto.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private async Task<string> Upload(IFormFile file)
    {
        if (file.IsNull() || file.Length == 0)
        {
            return null;
        }

        var arquivo = file.OpenReadStream().ToByteArray();
        //var pastaArquivo = Path.Combine(env.WebRootPath, "files", Path.GetExtension(file.FileName).Remove("."));
        var pastaArquivo = Path.Combine(env.WebRootPath, "files");
        var nomeArquivo = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        if (!Directory.Exists(pastaArquivo))
        {
            Directory.CreateDirectory(pastaArquivo);
        }

        var caminhoArquivo = Path.Combine(pastaArquivo, nomeArquivo);

        await System.IO.File.WriteAllBytesAsync(caminhoArquivo, arquivo);

        return nomeArquivo;
    }
}
