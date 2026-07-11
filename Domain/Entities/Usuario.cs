namespace Domain.Entities;

public sealed class Usuario : BaseEntity
{
    public Usuario(
        Guid id,
        DateTime dataDeCadastro,
        DateTime? dataDeAtualizacao, string? senha, string? telefone, string email, bool ativo, Guid pessoaId)
        : base(id, dataDeCadastro, dataDeAtualizacao)
    {
        Senha = senha;
        Telefone = telefone;
        Email = email;
        Ativo = ativo;
        PessoaId = pessoaId;
    }

    public string? Senha { get; private set; }
    public string? Telefone { get; private set; }
    public string Email { get; private set; }
    public bool Ativo { get; private set; }
    public Guid PessoaId { get; private set; }
    public Pessoa Pessoa { get; set; } = null!;
    public UsuarioEmail UsuarioEmail { get; set; } = null!;
}