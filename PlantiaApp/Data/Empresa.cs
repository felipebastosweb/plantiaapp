namespace PlantiaApp.Data;

using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

public partial class Empresa
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; } // ID SQLite
    public Guid RemoteId { get; set; } // ID do Servidor
    public string RazaoSocial { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public int EnderecoId { get; set; } // ID do SQLite para inclusão
    public virtual Endereco Endereco { get; set; } = null!; // Empresa belongs to Endereço
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
