using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Cria_VIEW_FuncisDepartamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW view_FuncionariosDepartamentos AS
                                    SELECT
                                        f.FuncionarioId, f.Nome AS NomeFuncionario,
                                        f.Cargo, f.Salario, f.DataContratacao, d.DepartamentoId,
                                        d.Nome AS NomeDepartamento, d.Descricao AS DescricaoDepartamento
                                    FROM 
                                        Funcionarios f
                                    INNER JOIN
                                        Departamentos d ON f.DepartamentoId = d.DepartamentoId;");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW view_FuncionariosDepartamentos;");
        }
    }
}
