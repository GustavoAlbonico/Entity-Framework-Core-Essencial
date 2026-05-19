using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class IncluiNumeroOrdemServicoProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "NumeroOSSequence",
                startValue: 2001L,
                incrementBy: 10,
                minValue: 2001L,
                maxValue: 999999L);

            migrationBuilder.AddColumn<int>(
                name: "numero_ordem_servico",
                table: "projetos",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR NumeroOSSequence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numero_ordem_servico",
                table: "projetos");

            migrationBuilder.DropSequence(
                name: "NumeroOSSequence");
        }
    }
}
