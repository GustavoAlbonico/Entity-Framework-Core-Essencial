using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class DuracaoEmDiasProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "duracao_em_dias",
                table: "projetos",
                type: "int",
                nullable: false,
                computedColumnSql: "DATEDIFF(day, DataInicio, DataFim)",
                stored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duracao_em_dias",
                table: "projetos");
        }
    }
}
