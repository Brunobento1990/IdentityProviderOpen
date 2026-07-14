using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class UsuarioProdutoAcessoConfiguracao : IEntityTypeConfiguration<UsuarioProdutoAcesso>
{
    public void Configure(EntityTypeBuilder<UsuarioProdutoAcesso> builder)
    {
        builder.HasKey(x => new { x.UsuarioId, x.ClienteProdutoId });
    }
}