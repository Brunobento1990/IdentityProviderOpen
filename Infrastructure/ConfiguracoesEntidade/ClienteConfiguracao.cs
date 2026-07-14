using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class ClienteConfiguracao : EntidadeBaseConfiguracao<Cliente>
{
    public override void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasIndex(x => x.Ativo);
        builder.HasIndex(x => new { x.Ativo, x.ParceiroId });

        base.Configure(builder);
    }
}