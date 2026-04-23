using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class IncluiFuncionarioEDetalhe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    salario = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    data_contratacao = table.Column<DateOnly>(type: "date", nullable: false),
                    departamento_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_funcionarios", x => x.id);
                    table.ForeignKey(
                        name: "fk_funcionarios_departamentos_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "funcionario_detalhes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    endereco_residencial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    celular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    genero = table.Column<int>(type: "int", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    estado_civil = table.Column<int>(type: "int", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    escolaridade = table.Column<int>(type: "int", nullable: false),
                    funcionario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_funcionario_detalhes", x => x.id);
                    table.ForeignKey(
                        name: "fk_funcionario_detalhes_funcionarios_funcionario_id",
                        column: x => x.funcionario_id,
                        principalTable: "funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_funcionario_detalhes_funcionario_id",
                table: "funcionario_detalhes",
                column: "funcionario_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_funcionarios_departamento_id",
                table: "funcionarios",
                column: "departamento_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionario_detalhes");

            migrationBuilder.DropTable(
                name: "funcionarios");
        }
    }
}
