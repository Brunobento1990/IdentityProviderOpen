using Domain.Entities;
using Infrastructure.ConfiguracoesEntidade;
using Infrastructure.Extensoes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Parceiro> Parceiros { get; set; }
    public DbSet<ParceiroMembro> ParceiroMembros { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioEmail> UsuarioEmails { get; set; }
    public DbSet<UsuarioProdutoAcesso> UsuarioProdutoAcessos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ParceiroConfiguracao());
        builder.ApplyConfiguration(new ParceiroMembroConfiguracao());
        builder.ApplyConfiguration(new PessoaConfiguracao());
        builder.ApplyConfiguration(new ProdutoConfiguracao());
        builder.ApplyConfiguration(new UsuarioConfiguracao());
        builder.ApplyConfiguration(new UsuarioEmailConfiguracao());
        builder.ApplyConfiguration(new UsuarioProdutoAcessoConfiguracao());

        builder.AddDadosIniciais();

        base.OnModelCreating(builder);
    }
}