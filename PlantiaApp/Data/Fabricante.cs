namespace PlantiaApp.Data;

using SQLite;

public partial class Fabricante
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public Guid RemoteId { get; set; }
    public string Nome { get; set; } = null!;
    public string Imagem { get; set; } = null!;
    public string Site { get; set; } = null!;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
}
