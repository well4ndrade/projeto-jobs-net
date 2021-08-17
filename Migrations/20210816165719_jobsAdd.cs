using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projeto_jobs_net.Migrations
{
    public partial class jobsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    cpf = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    rg = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    genero = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    telefone2 = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    profissao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    estadoCivil = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    possuiVeiculo = table.Column<string>(type: "varchar", nullable: true),
                    possuiHabilitacao = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vagas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vagas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    cidade = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    pais = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_enderecos_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_usuario_id",
                table: "enderecos",
                column: "usuario_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "vagas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
