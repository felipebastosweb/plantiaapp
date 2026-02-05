using System.ComponentModel.DataAnnotations.Schema;

namespace PlantiaApp.Site.Data;

public partial class Fornecedor
{
    // Um Fornecedor recebe muitos pedidos de compra
    public ICollection<Compra> Compras { get; set; } = [];
}

public partial class Compra
{
    public Guid Id { get; set; }
    public Guid FornecedorId { get; set; }
    [ForeignKey(nameof(FornecedorId))]
    public virtual Fornecedor Fornecedor { get; set; } = null!;
    public Guid EmpresaId { get; set; }
    [ForeignKey(nameof(EmpresaId))]
    public virtual Empresa Empresa { get; set; } = null!;
    public string UsuarioId { get; set; } = string.Empty;
    public DateTime DataCompra { get; set; }
    public decimal Total { get; set; }
    // Uma compra tem muitos itens
    public ICollection<CompraItem> Itens { get; set; } = [];
}

public class CompraItem
{
    public Guid Id { get; set; }
    public Guid CompraId { get; set; }
    [ForeignKey(nameof(CompraId))]
    public virtual Compra Compra { get; set; } = null!;
    public Guid ProdutoId { get; set; }
    [ForeignKey(nameof(ProdutoId))]
    public virtual Produto Produto { get; set; } = null!;
    public int Quantidade { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoUnitario { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Subtotal { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Total { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoVenda { get; set; }
}

public class Estoque
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    [ForeignKey(nameof(ProdutoId))]
    public virtual Produto Produto { get; set; } = null!;
    public int QuantidadeDisponivel { get; set; }
    public int QuantidadeMinima { get; set; }
    public ICollection<EstoqueMovimento> EstoqueMovimentos { get; set; } = [];
}

public class EstoqueMovimento
{
    public Guid Id { get; set; }
    public Guid CompraItemId { get; set; }
    [ForeignKey(nameof(CompraItemId))]
    public virtual CompraItem CompraItem { get; set; } = null!;
    public Guid VendaItemId { get; set; }
    [ForeignKey(nameof(VendaItemId))]
    public virtual VendaItem VendaItem { get; set; } = null!;
    public DateTime DataMovimento { get; set; }
    public decimal Quantidade { get; set; }
    public string TipoMovimento { get; set; } = string.Empty; // "Entrada" ou "Saída"
    public string? Observacao { get; set; }
}
