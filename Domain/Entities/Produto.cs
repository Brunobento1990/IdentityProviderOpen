namespace Domain.Entities;

public sealed class Produto : BaseEntity
{
    public Produto(
        Guid id,
        DateTime dataDeCadastro,
        DateTime? dataDeAtualizacao, string nome, bool ativo, Guid parceiroId)
        : base(id, dataDeCadastro, dataDeAtualizacao)
    {
        Nome = nome;
        Ativo = ativo;
        ParceiroId = parceiroId;
    }

    public string Nome { get; private set; }
    public bool Ativo { get; private set; }
    public Guid ParceiroId { get; private set; }
    public Parceiro Parceiro { get; set; } = null!;
}