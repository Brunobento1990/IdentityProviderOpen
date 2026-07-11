using Domain.ConfiguracaoEntidade;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class UsuarioConfiguracao : EntidadeBaseConfiguracao<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(UsuarioConfig.MaxLengthEmail);

        builder.Property(x => x.Telefone)
            .HasMaxLength(UsuarioConfig.MaxLengthTelefone);

        builder.Property(x => x.Senha)
            .HasMaxLength(1000);

        builder
            .HasIndex(x => x.Email)
            .HasFilter("\"Ativo\" = true")
            .IsUnique();

        base.Configure(builder);
    }
}