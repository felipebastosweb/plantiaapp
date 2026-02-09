namespace PlantiaApp.Data;

using SQLite;

public partial class Fornecedor
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; } // Id no SQLite
    public Guid RemoteId { get; set; } // Id no Servidor
    public string RazaoSocial { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public Guid EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; } = null!;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
