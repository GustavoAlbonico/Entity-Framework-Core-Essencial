using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_funcionario_departamentos_departamento_id",
                table: "funcionario");

            migrationBuilder.DropForeignKey(
                name: "fk_funcionario_detalhe_funcionario_funcionario_id",
                table: "funcionario_detalhe");

            migrationBuilder.DropPrimaryKey(
                name: "pk_funcionario_detalhe",
                table: "funcionario_detalhe");

            migrationBuilder.DropPrimaryKey(
                name: "pk_funcionario",
                table: "funcionario");

            migrationBuilder.RenameTable(
                name: "funcionario_detalhe",
                newName: "funcionario_detalhes");

            migrationBuilder.RenameTable(
                name: "funcionario",
                newName: "funcionarios");

            migrationBuilder.RenameIndex(
                name: "ix_funcionario_detalhe_funcionario_id",
                table: "funcionario_detalhes",
                newName: "ix_funcionario_detalhes_funcionario_id");

            migrationBuilder.RenameIndex(
                name: "ix_funcionario_departamento_id",
                table: "funcionarios",
                newName: "ix_funcionarios_departamento_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_funcionario_detalhes",
                table: "funcionario_detalhes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_funcionarios",
                table: "funcionarios",
                column: "id");

            migrationBuilder.CreateTable(
                name: "projetos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    orcamento = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projetos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios_projetos",
                columns: table => new
                {
                    funcionario_id = table.Column<int>(type: "int", nullable: false),
                    projeto_id = table.Column<int>(type: "int", nullable: false),
                    horas_trabalhadas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_funcionarios_projetos", x => new { x.funcionario_id, x.projeto_id });
                    table.ForeignKey(
                        name: "fk_funcionarios_projetos_funcionarios_funcionario_id",
                        column: x => x.funcionario_id,
                        principalTable: "funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_funcionarios_projetos_projetos_projeto_id",
                        column: x => x.projeto_id,
                        principalTable: "projetos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "funcionarios_projetos",
                columns: new[] { "funcionario_id", "projeto_id", "horas_trabalhadas" },
                values: new object[,]
                {
                    { 16, 1, 15 },
                    { 17, 7, 52 },
                    { 18, 2, 20 },
                    { 19, 3, 30 },
                    { 19, 4, 18 },
                    { 19, 6, 5 },
                    { 19, 7, 48 },
                    { 20, 5, 27 },
                    { 21, 5, 30 },
                    { 22, 2, 25 },
                    { 22, 6, 10 },
                    { 24, 1, 15 },
                    { 24, 7, 44 },
                    { 25, 4, 22 },
                    { 27, 7, 44 },
                    { 28, 3, 28 },
                    { 29, 3, 40 },
                    { 32, 4, 15 },
                    { 33, 5, 42 },
                    { 34, 5, 40 },
                    { 35, 5, 38 },
                    { 35, 7, 40 },
                    { 36, 5, 42 },
                    { 36, 7, 38 },
                    { 37, 7, 30 },
                    { 38, 5, 20 },
                    { 40, 7, 42 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_funcionarios_projetos_projeto_id",
                table: "funcionarios_projetos",
                column: "projeto_id");

            migrationBuilder.AddForeignKey(
                name: "fk_funcionario_detalhes_funcionarios_funcionario_id",
                table: "funcionario_detalhes",
                column: "funcionario_id",
                principalTable: "funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_funcionarios_departamentos_departamento_id",
                table: "funcionarios",
                column: "departamento_id",
                principalTable: "departamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_funcionario_detalhes_funcionarios_funcionario_id",
                table: "funcionario_detalhes");

            migrationBuilder.DropForeignKey(
                name: "fk_funcionarios_departamentos_departamento_id",
                table: "funcionarios");

            migrationBuilder.DropTable(
                name: "funcionarios_projetos");

            migrationBuilder.DropTable(
                name: "projetos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_funcionarios",
                table: "funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "pk_funcionario_detalhes",
                table: "funcionario_detalhes");

            migrationBuilder.RenameTable(
                name: "funcionarios",
                newName: "funcionario");

            migrationBuilder.RenameTable(
                name: "funcionario_detalhes",
                newName: "funcionario_detalhe");

            migrationBuilder.RenameIndex(
                name: "ix_funcionarios_departamento_id",
                table: "funcionario",
                newName: "ix_funcionario_departamento_id");

            migrationBuilder.RenameIndex(
                name: "ix_funcionario_detalhes_funcionario_id",
                table: "funcionario_detalhe",
                newName: "ix_funcionario_detalhe_funcionario_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_funcionario",
                table: "funcionario",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_funcionario_detalhe",
                table: "funcionario_detalhe",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_funcionario_departamentos_departamento_id",
                table: "funcionario",
                column: "departamento_id",
                principalTable: "departamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_funcionario_detalhe_funcionario_funcionario_id",
                table: "funcionario_detalhe",
                column: "funcionario_id",
                principalTable: "funcionario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
