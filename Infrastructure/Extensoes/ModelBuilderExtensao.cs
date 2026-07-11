using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensoes;

public static class ModelBuilderExtensao
{
    public static ModelBuilder AddDadosIniciais(this ModelBuilder builder)
    {
        var parceiroId = Guid.Parse("153527b1-215a-41fe-8f59-bff6fdb19634");
        var pessoaId = Guid.Parse("08a628cc-0b8a-4ad0-b339-d0b6951c7db0");
        var usuarioId = Guid.Parse("7904adbc-35d8-4bd4-9c30-a02bd1bd29ba");
        var usuarioEmailId = Guid.Parse("044f48b3-6ac1-4dbc-88d2-7d8702e50925");

        builder.Entity<Parceiro>().HasData(new Parceiro(
            id: parceiroId,
            dataDeCadastro: DateTime.MinValue,
            dataDeAtualizacao: null,
            razaoSocial: "Open adm software",
            nomeFantasia: "Open adm software LTDA",
            cnpj: "11501412000121",
            ativo: true));

        builder.Entity<Pessoa>()
            .HasData(new Pessoa(id: pessoaId,
                dataDeCadastro: DateTime.MinValue,
                dataDeAtualizacao: null,
                nome: "Seed",
                cpf: "15838321067"));

        builder.Entity<Usuario>()
            .HasData(new Usuario(id: usuarioId,
                dataDeCadastro: DateTime.MinValue,
                dataDeAtualizacao: null,
                senha: "$2a$10$GQ3dAzsw23bEqZ88hisWEObR0J7R3GOCwWb0hRk3cFETrLH9x0l7u",
                telefone: null,
                email: "seed@gmail.com",
                ativo: true,
                pessoaId: pessoaId));

        builder.Entity<UsuarioEmail>()
            .HasData(new UsuarioEmail(
                id: usuarioEmailId,
                dataDeCadastro: DateTime.MinValue,
                dataDeAtualizacao: null,
                emailVerificado: true,
                codigoEmail: null,
                dataExpiracaoCodigoEmail: null,
                ultimoPedidoEsqueceuSenha: null,
                usuarioId: usuarioId));

        return builder;
    }
}