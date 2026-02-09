namespace PlantiaApp.Site.Data;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string NomeSocial { get; set; } = null!;
    public DateOnly DataDeAniversariante { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
