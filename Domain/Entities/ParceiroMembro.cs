namespace Domain.Entities;

public class ParceiroMembro : BaseEntity
{
    public ParceiroMembro(
        Guid id,
        DateTime dataDeCadastro,
        DateTime? dataDeAtualizacao, Guid parceiroId, Guid usuarioId)
        : base(id, dataDeCadastro, dataDeAtualizacao)
    {
        ParceiroId = parceiroId;
        UsuarioId = usuarioId;
    }

    public Guid ParceiroId { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Parceiro Parceiro { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}