namespace Domain.Entities;

public sealed class Parceiro : BaseEntity
{
    public Parceiro(
        Guid id,
        DateTime dataDeCadastro,
        DateTime? dataDeAtualizacao, string razaoSocial, string nomeFantasia, string cnpj, bool ativo)
        : base(id, dataDeCadastro, dataDeAtualizacao)
    {
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
        Ativo = ativo;
    }

    public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }
    public bool Ativo { get; private set; }
}