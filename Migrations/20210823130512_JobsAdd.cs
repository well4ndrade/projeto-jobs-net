using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projeto_jobs_net.Migrations
{
    public partial class JobsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    passwd = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dados", x => x.id);
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
                    pais = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vagas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    local = table.Column<string>(type: "text", nullable: false),
                    salario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vagas", x => x.id);
                });

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
                    possuiHabilitacao = table.Column<string>(type: "varchar", nullable: true),
                    endereco_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_enderecos_endereco_id",
                        column: x => x.endereco_id,
                        principalTable: "enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_endereco_id",
                table: "usuarios",
                column: "endereco_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dados");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "vagas");

            migrationBuilder.DropTable(
                name: "enderecos");
        }
    }
}
