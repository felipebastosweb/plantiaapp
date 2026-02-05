namespace PlantiaApp.Site.Data;

using System.ComponentModel.DataAnnotations.Schema;


public partial class Fornecedor
{
    public Guid Id { get; set; }
    public string RazaoSocial { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public Guid EnderecoId { get; set; }
    [ForeignKey(nameof(EnderecoId))]
    public virtual Endereco Endereco { get; set; } = null!;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AlteradoEm { get; set; }
    public DateTime? ArquivadoEm { get; set; }
}
