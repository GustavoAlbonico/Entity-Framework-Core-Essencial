using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departamentos", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "departamentos",
                columns: new[] { "id", "descricao", "nome" },
                values: new object[,]
                {
                    { 1, "Gestão das finanças", "Financeiro" },
                    { 2, "Promoção de produtos", "Marketing" },
                    { 3, "Recursos Humanos", "RH" },
                    { 4, "Atendimento ao cliente", "Suporte" },
                    { 5, "Tecnologia da Informação", "TI" },
                    { 6, "Gestão de Vendas", "Vendas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departamentos");
        }
    }
}
