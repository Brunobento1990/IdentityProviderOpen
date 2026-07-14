namespace Domain.Entities;

public sealed class PessoaJuridica : BaseEntity
{
    public PessoaJuridica(
        Guid id,
        DateTime dataDeCadastro,
        DateTime? dataDeAtualizacao, string razaoSocial, string nomeFantasia, string cnpj)
        : base(id, dataDeCadastro, dataDeAtualizacao)
    {
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
    }
    
    public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }
}