using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ProjetoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cliente_id",
                table: "projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clientes", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "id", "ativo", "email", "nome", "telefone" },
                values: new object[,]
                {
                    { 1, true, "abroad@email.com", "Grupo ABroad SA", "55-11 9980-0099" },
                    { 2, true, "abcconstru@email.com", "Construtora ABC", "55-31 8957-1022" },
                    { 3, true, "edufuture@email.com", "EduFuture Corp.", "55-11 8750-4422" },
                    { 4, true, "innovators@email.com", "Tech Innovators Ltda", "55-11 9950-9622" },
                    { 5, false, "healtsolutions@email.com", "Health Solutions Inc.", "55-21 9852-9655" }
                });

            migrationBuilder.InsertData(
                table: "projetos",
                columns: new[] { "id", "cliente_id", "data_atualizacao", "data_fim", "data_inicio", "descricao", "nome", "orcamento", "status" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2026, 4, 20, 21, 44, 9, 552, DateTimeKind.Local).AddTicks(4210), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto A", "Projeto A", 1000000m, 3 },
                    { 2, 1, new DateTime(2026, 4, 20, 21, 44, 9, 565, DateTimeKind.Local).AddTicks(7851), new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto B", "Projeto B", 2000000m, 5 },
                    { 3, 5, new DateTime(2026, 4, 20, 21, 44, 9, 565, DateTimeKind.Local).AddTicks(7872), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto C", "Projeto C", 3000000m, 10 },
                    { 4, 3, new DateTime(2026, 4, 20, 21, 44, 9, 565, DateTimeKind.Local).AddTicks(7875), new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto D", "Projeto D", 4000000m, 10 },
                    { 5, 4, new DateTime(2026, 4, 20, 21, 44, 9, 565, DateTimeKind.Local).AddTicks(7877), new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto E", "Projeto E", 5000000m, 20 },
                    { 6, 1, new DateTime(2026, 4, 20, 21, 44, 9, 565, DateTimeKind.Local).AddTicks(7878), new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto F", "Projeto F", 6000000m, -1 },
                    { 7, 3, new DateTime(2026, 4, 20, 21, 44, 9, 565, DateTimeKind.Local).AddTicks(7881), new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto G", "Projeto G", 9000000m, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_projetos_cliente_id",
                table: "projetos",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "ix_clientes_email",
                table: "clientes",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_clientes_nome",
                table: "clientes",
                column: "nome");

            migrationBuilder.AddForeignKey(
                name: "fk_projetos_clientes_cliente_id",
                table: "projetos",
                column: "cliente_id",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projetos_clientes_cliente_id",
                table: "projetos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropIndex(
                name: "ix_projetos_cliente_id",
                table: "projetos");

            migrationBuilder.DeleteData(
                table: "projetos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "projetos",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "projetos",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "projetos",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "projetos",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "projetos",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "projetos",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "cliente_id",
                table: "projetos");
        }
    }
}
