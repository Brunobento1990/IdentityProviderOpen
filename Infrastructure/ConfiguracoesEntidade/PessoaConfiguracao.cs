using Domain.ConfiguracaoEntidade;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class PessoaConfiguracao : EntidadeBaseConfiguracao<Pessoa>
{
    public override void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(PessoaConfig.MaxLengthNome);

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasMaxLength(PessoaConfig.MaxLengthCpf);

        builder.HasIndex(x => x.Nome);
        builder.HasIndex(x => x.Cpf);

        base.Configure(builder);
    }
}