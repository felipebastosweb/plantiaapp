namespace PlantiaApp.Site.Data;

using SQLite;


public enum CompraEstado
{
    Rascunho,
    PendenteDeAprovacao,
    Confirmada,
    Recebida,
    Cancelada
}

public partial class Compra
{
    public int Id { get; set; }
    public Guid RemoteId { get; set; }
    // O UsuarioId é uma string que representa o ID do usuário (Funcionário) que fez a compra
    public string UsuarioId { get; set; } = string.Empty;
    public DateTime DataCompra { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Total { get; set; }
    [Column(TypeName = "decimal(7, 2)")]
    public decimal TotalTaxas { get; set; }
    [Column(TypeName = "decimal(7, 2)")]
    public decimal TotalDescontos { get; set; }
    [Column(TypeName = "decimal(7, 2)")]
    public decimal TotalFrete { get; set; }
    public CompraEstado Estado { get; set; } = CompraEstado.Rascunho;
    public DateTime? DataDaCompra { get; set; }
    public DateTime? DataPrevistaDeRecebimento { get; set; }
    public DateTime? DataDeRecebimento { get; set; }
    public Guid FornecedorId { get; set; }
    [ForeignKey(nameof(FornecedorId))]
    public virtual Fornecedor Fornecedor { get; set; } = null!;
    public Guid EmpresaId { get; set; }
    public virtual Empresa Empresa { get; set; } = null!;
    // Uma compra tem muitos itens
    public ICollection<CompraItem> Itens { get; set; } = [];
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}

public class CompraItem
{
    public int Id { get; set; }
    public Guid RemoteId { get; set; }
    public Guid CompraId { get; set; }
    public virtual Compra Compra { get; set; } = null!;
    public Guid ProdutoId { get; set; }
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
    public int Id { get; set; }
    public Guid RemoteId { get; set; }
    public Guid ProdutoId { get; set; }
    public virtual Produto Produto { get; set; } = null!;
    public int QuantidadeDisponivel { get; set; }
    public int QuantidadeMinima { get; set; }
    public ICollection<EstoqueMovimento> EstoqueMovimentos { get; set; } = [];
}

public class EstoqueMovimento
{
    public Guid Id { get; set; }
    public Guid CompraItemId { get; set; }
    public virtual CompraItem CompraItem { get; set; } = null!;
    public Guid VendaItemId { get; set; }
    [ForeignKey(nameof(VendaItemId))]
    public virtual VendaItem VendaItem { get; set; } = null!;
    public DateTime DataMovimento { get; set; }
    public decimal Quantidade { get; set; }
    public string TipoMovimento { get; set; } = string.Empty; // "Entrada" ou "Saída"
    public string? Observacao { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
