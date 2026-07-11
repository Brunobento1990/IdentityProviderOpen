namespace Domain.Entities;

public class UsuarioProdutoAcesso
{
    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; set; } = null!;
    public Guid ProdutoId { get; private set; }
    public Produto Produto { get; set; } = null!;
}