namespace PlantiaApp.Site.Data;


public class Endereco
{
    public Guid Id { get; set; }
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Latitude { get; set; } = string.Empty;
    public string Longitude { get; set; } = string.Empty;
}
