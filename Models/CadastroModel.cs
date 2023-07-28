using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ImobiliariaLM.RazorPages.Models;

public class CadastroModel
{
    [Key]
/*    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    public string Valor { get; set; }

    [Display(Name = "Casa ou apt?")]
    public string Categoria { get; set; }

    [Display(Name = "Venda ou aluguel?")]
    public string VendaAluguel { get; set; }

    public string? CEP { get; set; }

    [Display(Name = "Endereço")]
    public string? Endereco { get; set; }

    public string Cidade { get; set; }

    public string Bairro { get; set; }

    public string Complemento { get; set; }

    [Display(Name = "Quantidade de metros do imóvel")]
    public string MtQuadrado { get; set; }

    [Display(Name = "Quantidade de Baneiro")]
    public string QtdBanheiros { get; set; }

    [Display(Name = "Quantidade de quartos")]
    public string QtdQuartos { get; set; }

    [Display(Name = "Quantidade de vagas")]
    public string QtdVagas { get; set; }

    [NotMapped]
    public IFormFile Imagem { get; set; }

    public string? NomeImagemImovel { get; set; }
}
