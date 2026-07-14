namespace Domain.Entities;

public class ClienteProduto : BaseEntity
{
    public ClienteProduto(
        Guid id,
        DateTime dataDeCadastro,
        DateTime? dataDeAtualizacao, Guid clienteId, Guid produtoId, bool ativo)
        : base(id, dataDeCadastro, dataDeAtualizacao)
    {
        ClienteId = clienteId;
        ProdutoId = produtoId;
        Ativo = ativo;
    }

    public Guid ClienteId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public Produto Produto { get; set; } = null!;
    public Cliente Cliente { get; set; } = null!;
    public bool Ativo { get; private set; }
}