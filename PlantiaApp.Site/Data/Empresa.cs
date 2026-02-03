namespace PlantiaApp.Site.Data;

public partial class Empresa
{
    public Guid Id { get; set; }
    public string RazaoSocial { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public Guid EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; } = null!;
}
