using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class UsuarioEmailConfiguracao : EntidadeBaseConfiguracao<UsuarioEmail>
{
    public override void Configure(EntityTypeBuilder<UsuarioEmail> builder)
    {
        builder.HasIndex(x => x.CodigoEmail);
        builder.HasIndex(x => x.EmailVerificado);
        
        base.Configure(builder);
    }
}