using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfiguracoesEntidade;

internal class EntidadeBaseConfiguracao<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataDeCadastro)
            .IsRequired()
            .HasDefaultValueSql("now()");
    }
}