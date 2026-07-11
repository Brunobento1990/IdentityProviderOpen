using Domain.ConfiguracaoEntidade;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class ParceiroConfiguracao : EntidadeBaseConfiguracao<Parceiro>
{
    public override void Configure(EntityTypeBuilder<Parceiro> builder)
    {
        builder.Property(x => x.NomeFantasia)
            .IsRequired()
            .HasMaxLength(ParceiroConfig.MaxLengthNomeFantasia);

        builder.Property(x => x.RazaoSocial)
            .IsRequired()
            .HasMaxLength(ParceiroConfig.MaxLengthRazaoSocial);

        builder.Property(x => x.Cnpj)
            .IsRequired()
            .HasMaxLength(ParceiroConfig.MaxLengthCnpj);

        builder.HasIndex(x => x.RazaoSocial).IsUnique();
        builder.HasIndex(x => x.Cnpj).IsUnique();

        base.Configure(builder);
    }
}