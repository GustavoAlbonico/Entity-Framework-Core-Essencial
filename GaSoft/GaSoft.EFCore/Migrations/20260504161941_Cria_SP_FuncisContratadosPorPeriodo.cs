using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Cria_SP_FuncisContratadosPorPeriodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE usp_FuncionariosContratadosPorPeriodo
                                        @DataInicio DATE,
                                        @DataFim DATE
                                    AS
                                    BEGIN
                                        SELECT f.FuncionarioId,f.Nome,f.Cargo,f.Salario,f.DataContratacao,f.DepartamentoId
                                        FROM Funcionarios f
                                        WHERE f.DataContratacao BETWEEN @DataInicio AND @DataFim
                                        ORDER BY f.DataContratacao;
                                    END;
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_FuncionariosContratadosPorPeriodo;");
        }
    }
}
