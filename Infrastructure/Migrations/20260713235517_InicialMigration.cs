using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RazaoSocial = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NomeFantasia = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    DataDeAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    DataDeAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoasJuridicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RazaoSocial = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NomeFantasia = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    DataDeAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasJuridicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    ParceiroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    DataDeAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Parceiros_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Senha = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    DataDeAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PessoaJuridicaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParceiroId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    DataDeAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Parceiros_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_PessoasJuridicas_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoasJuridicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEmails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailVerificado = table.Column<bool>(type: "boolean", nullable: false),
                    CodigoEmail = table.Column<Guid>(type: "uuid", nullable: true),
                    DataExpiracaoCodigoEmail = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UltimoPedidoEsqueceuSenha = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    DataDeAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEmails_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataDeAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteProduto_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioProdutoAcessos",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteProdutoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioProdutoAcessos", x => new { x.UsuarioId, x.ClienteProdutoId });
                    table.ForeignKey(
                        name: "FK_UsuarioProdutoAcessos_ClienteProduto_ClienteProdutoId",
                        column: x => x.ClienteProdutoId,
                        principalTable: "ClienteProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioProdutoAcessos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parceiros",
                columns: new[] { "Id", "Ativo", "Cnpj", "DataDeAtualizacao", "NomeFantasia", "RazaoSocial" },
                values: new object[] { new Guid("153527b1-215a-41fe-8f59-bff6fdb19634"), true, "11501412000121", null, "Open adm software LTDA", "Open adm software" });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "Id", "Cpf", "DataDeAtualizacao", "Nome" },
                values: new object[] { new Guid("08a628cc-0b8a-4ad0-b339-d0b6951c7db0"), "15838321067", null, "Seed" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "DataDeAtualizacao", "Email", "PessoaId", "Senha", "Telefone" },
                values: new object[] { new Guid("7904adbc-35d8-4bd4-9c30-a02bd1bd29ba"), true, null, "seed@gmail.com", new Guid("08a628cc-0b8a-4ad0-b339-d0b6951c7db0"), "$2a$10$GQ3dAzsw23bEqZ88hisWEObR0J7R3GOCwWb0hRk3cFETrLH9x0l7u", null });

            migrationBuilder.InsertData(
                table: "UsuarioEmails",
                columns: new[] { "Id", "CodigoEmail", "DataDeAtualizacao", "DataExpiracaoCodigoEmail", "EmailVerificado", "UltimoPedidoEsqueceuSenha", "UsuarioId" },
                values: new object[] { new Guid("044f48b3-6ac1-4dbc-88d2-7d8702e50925"), null, null, null, true, null, new Guid("7904adbc-35d8-4bd4-9c30-a02bd1bd29ba") });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteProduto_ClienteId",
                table: "ClienteProduto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteProduto_ProdutoId",
                table: "ClienteProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Ativo",
                table: "Clientes",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Ativo_ParceiroId",
                table: "Clientes",
                columns: new[] { "Ativo", "ParceiroId" });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ParceiroId",
                table: "Clientes",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PessoaJuridicaId",
                table: "Clientes",
                column: "PessoaJuridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parceiros_Cnpj",
                table: "Parceiros",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parceiros_RazaoSocial",
                table: "Parceiros",
                column: "RazaoSocial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Cpf",
                table: "Pessoas",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Nome",
                table: "Pessoas",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasJuridicas_Cnpj",
                table: "PessoasJuridicas",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoasJuridicas_RazaoSocial",
                table: "PessoasJuridicas",
                column: "RazaoSocial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Ativo_ParceiroId",
                table: "Produtos",
                columns: new[] { "Ativo", "ParceiroId" });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Ativo_ParceiroId_Nome",
                table: "Produtos",
                columns: new[] { "Ativo", "ParceiroId", "Nome" });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ParceiroId_Nome",
                table: "Produtos",
                columns: new[] { "ParceiroId", "Nome" },
                unique: true,
                filter: "\"Ativo\" = true");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmails_CodigoEmail",
                table: "UsuarioEmails",
                column: "CodigoEmail");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmails_EmailVerificado",
                table: "UsuarioEmails",
                column: "EmailVerificado");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmails_UsuarioId",
                table: "UsuarioEmails",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProdutoAcessos_ClienteProdutoId",
                table: "UsuarioProdutoAcessos",
                column: "ClienteProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true,
                filter: "\"Ativo\" = true");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PessoaId",
                table: "Usuarios",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioEmails");

            migrationBuilder.DropTable(
                name: "UsuarioProdutoAcessos");

            migrationBuilder.DropTable(
                name: "ClienteProduto");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "PessoasJuridicas");

            migrationBuilder.DropTable(
                name: "Parceiros");
        }
    }
}
