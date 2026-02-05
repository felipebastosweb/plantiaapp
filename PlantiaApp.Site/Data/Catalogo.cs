namespace PlantiaApp.Site.Data;

using System.ComponentModel.DataAnnotations.Schema;

public partial class Fabricante
{
    public ICollection<Produto> Produtos { get; set; } = [];
}

public class Categoria
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Imagem { get; set; } = null!;
    // Uma categoria tem muitos produtos através da tabela de junção CategoriaProduto
    public ICollection<CategoriaProduto> CategoriaProdutos { get; set; } = [];
}


public partial class Produto
{
    public Guid Id { get; set; }
    public Guid FabricanteId { get; set; }
    [ForeignKey(nameof(FabricanteId))]
    public virtual Fabricante Fabricante { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Imagem { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    // Uma produto tem muitas categorias através da tabela de junção CategoriaProduto
    public ICollection<CategoriaProduto> CategoriaProdutos { get; set; } = [];

}

public class CategoriaProduto
{
    public Guid Id { get; set; }
    public Guid CategoriaId { get; set; }
    [ForeignKey(nameof(CategoriaId))]
    public virtual Categoria Categoria { get; set; } = null!;
    public Guid ProdutoId { get; set; }
    [ForeignKey(nameof(ProdutoId))]
    public virtual Produto Produto { get; set; } = null!;
}
