using System.Runtime.ExceptionServices;

namespace Domain.Entities;

public sealed class UsuarioEmail : BaseEntity
{
    public UsuarioEmail(
        Guid id, DateTime dataDeCadastro, DateTime? dataDeAtualizacao, bool emailVerificado, Guid? codigoEmail,
        DateTime? dataExpiracaoCodigoEmail, DateTime? ultimoPedidoEsqueceuSenha, Guid usuarioId) : base(id,
        dataDeCadastro, dataDeAtualizacao)
    {
        EmailVerificado = emailVerificado;
        CodigoEmail = codigoEmail;
        DataExpiracaoCodigoEmail = dataExpiracaoCodigoEmail;
        UltimoPedidoEsqueceuSenha = ultimoPedidoEsqueceuSenha;
        UsuarioId = usuarioId;
    }
    
    public bool EmailVerificado { get; private set; }
    public Guid? CodigoEmail { get; private set; }
    public DateTime? DataExpiracaoCodigoEmail { get; private set; }
    public DateTime? UltimoPedidoEsqueceuSenha { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; set; } = null!;
}