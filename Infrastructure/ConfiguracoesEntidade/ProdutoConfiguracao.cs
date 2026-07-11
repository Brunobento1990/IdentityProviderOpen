using Domain.ConfiguracaoEntidade;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class ProdutoConfiguracao : EntidadeBaseConfiguracao<Produto>
{
    public override void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(ProdutoConfig.MaxLengthNome);

        builder.HasIndex(x => new { x.Ativo, x.ParceiroId });
        builder.HasIndex(x => new { x.Ativo, x.ParceiroId, x.Nome });
        builder
            .HasIndex(x => new { x.ParceiroId, x.Nome })
            .HasFilter("\"Ativo\" = true")
            .IsUnique();

        base.Configure(builder);
    }
}