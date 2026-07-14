namespace Domain.Entities;

public class UsuarioProdutoAcesso
{
    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; set; } = null!;
    public Guid ClienteProdutoId { get; private set; }
    public ClienteProduto ClienteProduto { get; set; } = null!;
}