namespace PlantiaApp.Site.Data;

public partial class Fabricante
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Imagem { get; set; } = null!;
    public string Site { get; set; } = null!;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
}
