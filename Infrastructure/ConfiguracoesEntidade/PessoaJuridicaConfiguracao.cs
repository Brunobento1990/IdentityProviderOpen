using Domain.ConfiguracaoEntidade;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class PessoaJuridicaConfiguracao : EntidadeBaseConfiguracao<PessoaJuridica>
{
    public override void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.Property(x => x.NomeFantasia)
            .IsRequired()
            .HasMaxLength(PessoaJuridicaConfig.MaxLengthNomeFantasia);

        builder.Property(x => x.RazaoSocial)
            .IsRequired()
            .HasMaxLength(PessoaJuridicaConfig.MaxLengthRazaoSocial);

        builder.Property(x => x.Cnpj)
            .IsRequired()
            .HasMaxLength(PessoaJuridicaConfig.MaxLengthCnpj);

        builder.HasIndex(x => x.RazaoSocial).IsUnique();
        builder.HasIndex(x => x.Cnpj).IsUnique();
        
        base.Configure(builder);
    }
}