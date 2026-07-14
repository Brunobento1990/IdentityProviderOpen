namespace Domain.Entities;

public sealed class Cliente : BaseEntity
{
    public Cliente(
        Guid id,
        DateTime dataDeCadastro,
        DateTime? dataDeAtualizacao, Guid pessoaJuridicaId, Guid parceiroId, bool ativo)
        : base(id, dataDeCadastro, dataDeAtualizacao)
    {
        PessoaJuridicaId = pessoaJuridicaId;
        ParceiroId = parceiroId;
        Ativo = ativo;
    }

    public Guid PessoaJuridicaId { get; private set; }
    public Guid ParceiroId { get; private set; }
    public Parceiro Parceiro { get; set; } = null!;
    public PessoaJuridica PessoaJuridica { get; set; } = null!;
    public bool Ativo { get; private set; }
    public ICollection<ClienteProduto> Produtos { get; set; } = [];
}