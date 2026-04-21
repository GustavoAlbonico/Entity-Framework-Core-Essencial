using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class IncluiFuncionarioEDetalhe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionario",
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
                    table.PrimaryKey("pk_funcionario", x => x.id);
                    table.ForeignKey(
                        name: "fk_funcionario_departamentos_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "funcionario_detalhe",
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
                    table.PrimaryKey("pk_funcionario_detalhe", x => x.id);
                    table.ForeignKey(
                        name: "fk_funcionario_detalhe_funcionario_funcionario_id",
                        column: x => x.funcionario_id,
                        principalTable: "funcionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "funcionario",
                columns: new[] { "id", "cargo", "data_contratacao", "departamento_id", "nome", "salario" },
                values: new object[,]
                {
                    { 1, "Gerente de Finanças", new DateOnly(2023, 1, 15), 1, "João da Silva", 5250.00m },
                    { 2, "Analista Financeiro", new DateOnly(2021, 11, 10), 1, "Carlos Pereira", 4500.00m },
                    { 3, "Analista Financeiro", new DateOnly(2022, 2, 15), 1, "Ana Souza", 4300.00m },
                    { 4, "Técnico em Contabilidade", new DateOnly(2023, 4, 5), 1, "Fernanda Oliveira", 3400.00m },
                    { 5, "Técnico em Contabilidade", new DateOnly(2023, 7, 18), 1, "José Santos", 3400.00m },
                    { 6, "Analista de Marketing", new DateOnly(2021, 11, 10), 2, "Lucia Benitez", 4500.00m },
                    { 7, "Analista de Marketing", new DateOnly(2022, 8, 22), 2, "Pedro Cardoso", 4100.00m },
                    { 8, "Gerente de Marketing", new DateOnly(2023, 3, 1), 2, "Fabiana Costa", 5100.00m },
                    { 9, "Analista de Recursos Humanos", new DateOnly(2021, 9, 20), 3, "Roberto Ferreira", 3400.00m },
                    { 10, "Gerente de Recursos Humanos", new DateOnly(2022, 3, 10), 3, "Beatriz Almeida", 5000.00m },
                    { 11, "Analista de Recursos Humanos", new DateOnly(2023, 5, 5), 3, "Mariana Dias", 3000.00m },
                    { 12, "Analista de Suporte", new DateOnly(2022, 6, 15), 4, "Juliana Mendes", 3200.00m },
                    { 13, "Gerente de Suporte", new DateOnly(2022, 8, 22), 4, "Rafael Souza", 5800.00m },
                    { 14, "Analista de Suporte", new DateOnly(2023, 1, 1), 4, "Bruno Costa", 4000.00m },
                    { 15, "Analista de Suporte", new DateOnly(2023, 3, 10), 4, "Aline Dias", 3900.00m },
                    { 16, "Analista de TI", new DateOnly(2021, 11, 10), 5, "Felix Carvalho", 4800.00m },
                    { 17, "Programador Senior", new DateOnly(2022, 6, 5), 5, "Gustavo Almeida", 4500.00m },
                    { 18, "Analista de TI", new DateOnly(2021, 5, 18), 5, "Renata Silva", 4800.00m },
                    { 19, "Gerente de TI", new DateOnly(2023, 4, 15), 5, "Thiago Souza", 6600.00m },
                    { 20, "Engenheiro de Software", new DateOnly(2023, 5, 10), 5, "Vanessa Oliveira", 5250.00m },
                    { 21, "Analista de TI", new DateOnly(2023, 8, 1), 5, "Leandro Pereira", 4800.00m },
                    { 22, "Programador Junior", new DateOnly(2021, 11, 10), 5, "Fernando Carvalho", 2500.00m },
                    { 23, "Programador Junior", new DateOnly(2023, 3, 13), 5, "Gilberto Almeida", 2300.00m },
                    { 24, "Programador Junior", new DateOnly(2022, 5, 20), 5, "Renata Silva", 2800.00m },
                    { 25, "Programador Junior", new DateOnly(2023, 4, 5), 5, "Tamirez Souza", 2600.00m },
                    { 26, "Arquiteta de Software", new DateOnly(2023, 5, 10), 5, "Vanessa Oliveira", 5000.00m },
                    { 27, "Programador Senior", new DateOnly(2023, 8, 1), 5, "Leonardo Pereira", 5500.00m },
                    { 28, "Programador Senior", new DateOnly(2021, 10, 10), 5, "Maria Benitez", 5100.00m },
                    { 29, "Programador Senior", new DateOnly(2022, 2, 11), 5, "Ricardo Pereira", 4500.00m },
                    { 30, "Programador Senior", new DateOnly(2023, 8, 1), 5, "Paula Santos", 3200.00m },
                    { 31, "Programador Senior", new DateOnly(2023, 8, 1), 5, "Leonardo Pereira", 4650.00m },
                    { 32, "Arquiteto de Software", new DateOnly(2021, 10, 10), 5, "Maria Benitez", 5200.00m },
                    { 33, "Programador Senior", new DateOnly(2022, 2, 10), 5, "Reinaldo Pedreira", 4500.00m },
                    { 34, "Programador Senior", new DateOnly(2022, 4, 20), 5, "Helena Cintra", 4600.00m },
                    { 35, "Programador Senior", new DateOnly(2021, 9, 20), 5, "Carlos Santos", 4500.00m },
                    { 36, "Programador Senior", new DateOnly(2023, 8, 1), 5, "Leonardo Ramirez", 4500.00m },
                    { 37, "Engenheiro de Testes", new DateOnly(2021, 10, 10), 5, "Amanda Sanches", 5200.00m },
                    { 38, "Engenheiro de Testes", new DateOnly(2023, 2, 5), 5, "Rodrigo Pereira", 4800.00m },
                    { 39, "Engenheiro de Testes", new DateOnly(2022, 5, 20), 5, "Alicia Santos", 5300.00m },
                    { 40, "Arquiteto de Software", new DateOnly(2022, 6, 20), 5, "Paulo Mellado", 5800.00m },
                    { 41, "Gerente de Vendas", new DateOnly(2021, 10, 10), 6, "Marta Carvalho", 5200.00m },
                    { 42, "Representante de Vendas", new DateOnly(2022, 2, 15), 6, "Ricardo Sanches", 4500.00m },
                    { 43, "Assistente de Vendas", new DateOnly(2022, 5, 20), 6, "Patrícia Santos", 3200.00m },
                    { 44, "Representante de Vendas", new DateOnly(2022, 7, 18), 6, "Alberto Lima", 4800.00m },
                    { 45, "Assistente de Vendas", new DateOnly(2023, 6, 10), 6, "Rogério Oliveira", 3700.00m }
                });

            migrationBuilder.InsertData(
                table: "funcionario_detalhe",
                columns: new[] { "id", "cpf", "celular", "data_nascimento", "endereco_residencial", "escolaridade", "estado_civil", "foto", "funcionario_id", "genero", "nacionalidade" },
                values: new object[,]
                {
                    { 1, "12345678901", "999999999", new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua A, 123", 4, 1, "foto1.jpg", 1, 0, "Brasileiro" },
                    { 2, "23456789012", "988888888", new DateTime(1988, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua B, 234", 1, 0, "foto2.jpg", 2, 0, "Brasileiro" },
                    { 3, "34567890123", "977777777", new DateTime(1992, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua C, 345", 5, 1, "foto3.jpg", 3, 1, "Brasileiro" },
                    { 4, "45678901234", "966666666", new DateTime(1985, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua D, 456", 4, 2, "foto4.jpg", 4, 0, "Brasileiro" },
                    { 5, "56789012345", "955555555", new DateTime(1994, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua E, 567", 1, 1, "foto5.jpg", 5, 1, "Brasileiro" },
                    { 6, "67890123456", "944444444", new DateTime(1989, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua F, 678", 5, 0, "foto6.jpg", 6, 0, "Brasileiro" },
                    { 7, "78901234567", "933333333", new DateTime(1991, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua G, 789", 1, 1, "foto7.jpg", 7, 1, "Brasileiro" },
                    { 8, "89012345678", "922222222", new DateTime(1986, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua H, 890", 5, 0, "foto8.jpg", 8, 0, "Brasileiro" },
                    { 9, "90123456789", "911111111", new DateTime(1993, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua I, 901", 4, 1, "foto9.jpg", 9, 1, "Brasileiro" },
                    { 10, "01234567890", "900000000", new DateTime(1995, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua J, 101", 1, 0, "foto10.jpg", 10, 0, "Brasileiro" },
                    { 11, "11111100111", "988888888", new DateTime(1987, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua K, 111", 4, 1, "foto11.jpg", 11, 1, "Brasileiro" },
                    { 12, "22222112222", "977777777", new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua L, 121", 5, 0, "foto12.jpg", 12, 0, "Brasileiro" },
                    { 13, "33333322333", "966666666", new DateTime(1991, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua M, 131", 1, 1, "foto13.jpg", 13, 1, "Brasileiro" },
                    { 14, "44444114444", "955555555", new DateTime(1992, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua N, 141", 4, 0, "foto14.jpg", 14, 0, "Brasileiro" },
                    { 15, "55555533555", "944444444", new DateTime(1993, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua O, 151", 1, 1, "foto15.jpg", 15, 1, "Brasileiro" },
                    { 16, "66666446666", "933333333", new DateTime(1994, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua P, 161", 5, 0, "foto16.jpg", 16, 0, "Brasileiro" },
                    { 17, "77777777777", "922222222", new DateTime(1995, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua Q, 171", 1, 1, "foto17.jpg", 17, 1, "Brasileiro" },
                    { 18, "87788888888", "911111111", new DateTime(1996, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua R, 181", 2, 2, "foto18.jpg", 18, 0, "Brasileiro" },
                    { 19, "99999799999", "900000000", new DateTime(1997, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua S, 191", 5, 1, "foto19.jpg", 19, 1, "Brasileiro" },
                    { 20, "00100000000", "988888888", new DateTime(1988, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua T, 201", 1, 0, "foto20.jpg", 20, 0, "Brasileiro" },
                    { 21, "11112222202", "977777777", new DateTime(1989, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua U, 211", 1, 1, "foto21.jpg", 21, 1, "Brasileiro" },
                    { 22, "22223033333", "966666666", new DateTime(1990, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua V, 521", 5, 0, "foto22.jpg", 22, 0, "Brasileiro" },
                    { 23, "33334444044", "955555555", new DateTime(1991, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua W, 231", 1, 1, "foto23.jpg", 23, 1, "Brasileiro" },
                    { 24, "44045555555", "944444444", new DateTime(1992, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua X, 141", 4, 2, "foto24.jpg", 24, 0, "Brasileiro" },
                    { 25, "55556606666", "933333333", new DateTime(1993, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua Y, 251", 2, 1, "foto25.jpg", 25, 1, "Brasileiro" },
                    { 26, "66667777777", "922222222", new DateTime(1994, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua Z, 461", 5, 1, "foto26.jpg", 26, 0, "Brasileiro" },
                    { 27, "77778888888", "911111111", new DateTime(1995, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua AA, 271", 1, 3, "foto27.jpg", 27, 1, "Brasileiro" },
                    { 28, "88889999999", "900000000", new DateTime(1996, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua AB, 181", 4, 0, "foto28.jpg", 28, 0, "Brasileiro" },
                    { 29, "11182222222", "977777777", new DateTime(1989, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua UU, 271", 4, 1, "foto29.jpg", 29, 0, "Brasileiro" },
                    { 30, "22229333333", "966646666", new DateTime(1990, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua VV, 241", 5, 0, "foto30.jpg", 30, 0, "Brasileiro" },
                    { 31, "33335444444", "955557555", new DateTime(1991, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua WW, 261", 2, 1, "foto31.jpg", 31, 1, "Brasileiro" },
                    { 32, "44447555555", "944448444", new DateTime(1992, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua XX, 801", 4, 1, "foto32.jpg", 32, 0, "Brasileiro" },
                    { 33, "55556666966", "93333383", new DateTime(1993, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua YY, 21", 1, 1, "foto33.jpg", 33, 1, "Brasileiro" },
                    { 34, "66667477777", "922222322", new DateTime(1994, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua ZZ, 121", 5, 0, "foto34.jpg", 34, 0, "Brasileiro" },
                    { 35, "77778881888", "911111011", new DateTime(1995, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua AAA, 21", 2, 3, "foto35.jpg", 35, 0, "Brasileiro" },
                    { 36, "88882999999", "900001100", new DateTime(1996, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua ABC, 28", 4, 0, "foto36.jpg", 36, 0, "Brasileiro" },
                    { 37, "44445555555", "944440044", new DateTime(1992, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua XYC, 24", 4, 0, "foto37.jpg", 37, 0, "Brasileiro" },
                    { 38, "55556666766", "933300333", new DateTime(1993, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua YED, 21", 1, 1, "foto38.jpg", 38, 0, "Brasileiro" },
                    { 39, "66367777777", "922112222", new DateTime(1994, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua ZAB, 191", 2, 2, "foto39.jpg", 39, 0, "Brasileiro" },
                    { 40, "77778880888", "911001111", new DateTime(1995, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua AAT, 601", 1, 1, "foto40.jpg", 40, 1, "Brasileiro" },
                    { 41, "88889199999", "900110000", new DateTime(1996, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua ABR, 721", 2, 0, "foto41.jpg", 41, 0, "Brasileiro" },
                    { 42, "99990000000", "988778888", new DateTime(1997, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua ACY, 210", 5, 1, "foto42.jpg", 42, 1, "Brasileiro" },
                    { 43, "99990000002", "988779888", new DateTime(1998, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua ADX, 39", 2, 1, "foto43.jpg", 43, 1, "Brasileiro" },
                    { 44, "99990700001", "988770866", new DateTime(1998, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua AJW, 491", 1, 2, "foto44.jpg", 44, 0, "Brasileiro" },
                    { 45, "00001111111", "977776777", new DateTime(1988, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua ADT, 501", 2, 0, "foto45.jpg", 45, 0, "Brasileiro" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_funcionario_departamento_id",
                table: "funcionario",
                column: "departamento_id");

            migrationBuilder.CreateIndex(
                name: "ix_funcionario_detalhe_funcionario_id",
                table: "funcionario_detalhe",
                column: "funcionario_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionario_detalhe");

            migrationBuilder.DropTable(
                name: "funcionario");
        }
    }
}
