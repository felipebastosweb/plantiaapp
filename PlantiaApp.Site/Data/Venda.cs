namespace PlantiaApp.Site.Data;

public class Venda
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    [ForeignKey(nameof(ClienteId))]
    public virtual Cliente Cliente { get; set; } = null!;
    public decimal Total { get; set; }
    public ICollection<VendaItem> VendaItems { get; set; } = [];
}


public class VendaItem
{
    public Guid Id { get; set; }
    public Guid VendaId { get; set; }
    [ForeignKey(nameof(VendaId))]
    public virtual Venda Venda { get; set; } = null
    public Guid CompraItemId { get; set; }
    [ForeignKey(nameof(CompraItemId))]
    public virtual CompraItem CompraItem { get; set; } = null!;
    public decimal PrecoUnitario { get; set; }
    public decimal Quantidade { get; set; }
    public decimal Total { get; set; }
    public ICollection<VendaItem> VendaItems { get; set; } = [];
}
