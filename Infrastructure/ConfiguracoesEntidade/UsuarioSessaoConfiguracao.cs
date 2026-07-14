using Domain.ConfiguracaoEntidade;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class UsuarioSessaoConfiguracao : EntidadeBaseConfiguracao<UsuarioSessao>
{
    public override void Configure(EntityTypeBuilder<UsuarioSessao> builder)
    {
        builder.Property(x => x.RefreshTokenHash)
            .IsRequired()
            .HasMaxLength(UsuarioSessaoConfig.MaxLengthRefreshTokenHash);

        builder.Property(x => x.EnderecoIp)
            .HasMaxLength(UsuarioSessaoConfig.MaxLengthEnderecoIp);

        builder.Property(x => x.UserAgent)
            .HasMaxLength(UsuarioSessaoConfig.MaxLengthUserAgent);

        builder.Property(x => x.SistemaOperacional)
            .HasMaxLength(UsuarioSessaoConfig.MaxLengthSistemaOperacional);

        builder.Property(x => x.Navegador)
            .HasMaxLength(UsuarioSessaoConfig.MaxLengthNavegador);

        builder.Property(x => x.Dispositivo)
            .HasMaxLength(UsuarioSessaoConfig.MaxLengthDispositivo);

        builder.HasIndex(x => x.SessaoId).IsUnique();

        base.Configure(builder);
    }
}