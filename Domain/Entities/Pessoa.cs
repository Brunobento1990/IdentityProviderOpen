namespace Domain.Entities;

public sealed class Pessoa : BaseEntity
{
    public Pessoa(
        Guid id,
        DateTime dataDeCadastro,
        DateTime? dataDeAtualizacao, string nome, string cpf)
        : base(id, dataDeCadastro, dataDeAtualizacao)
    {
        Nome = nome;
        Cpf = cpf;
    }

    public string Nome { get; private set; }
    public string Cpf { get; private set; }
}