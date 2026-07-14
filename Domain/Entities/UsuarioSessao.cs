namespace Domain.Entities;

public sealed class UsuarioSessao : BaseEntity
{
    public UsuarioSessao(
        Guid id,
        DateTime dataDeCadastro,
        DateTime? dataDeAtualizacao, Guid usuarioId, string refreshTokenHash, DateTime? ultimaAtividadeEm,
        DateTime expiraEm, DateTime? revogadoEm, string? enderecoIp, string? userAgent, string? sistemaOperacional,
        string? navegador, string? dispositivo, Guid sessaoId)
        : base(id, dataDeCadastro, dataDeAtualizacao)
    {
        UsuarioId = usuarioId;
        RefreshTokenHash = refreshTokenHash;
        UltimaAtividadeEm = ultimaAtividadeEm;
        ExpiraEm = expiraEm;
        RevogadoEm = revogadoEm;
        EnderecoIp = enderecoIp;
        UserAgent = userAgent;
        SistemaOperacional = sistemaOperacional;
        Navegador = navegador;
        Dispositivo = dispositivo;
        SessaoId = sessaoId;
    }

    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; set; } = null!;
    public string RefreshTokenHash { get; private set; }
    public DateTime? UltimaAtividadeEm { get; private set; }
    public DateTime ExpiraEm { get; private set; }
    public DateTime? RevogadoEm { get; private set; }
    public string? EnderecoIp { get; private set; }
    public string? UserAgent { get; private set; }
    public string? SistemaOperacional { get; private set; }
    public string? Navegador { get; private set; }
    public string? Dispositivo { get; private set; }
    public Guid SessaoId { get; private set; }

    public bool Ativa =>
        RevogadoEm == null &&
        ExpiraEm > DateTime.UtcNow;
}