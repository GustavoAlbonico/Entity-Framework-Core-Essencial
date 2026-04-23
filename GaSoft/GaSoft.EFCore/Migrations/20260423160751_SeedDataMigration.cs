using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "funcionarios",
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
                table: "projetos",
                columns: new[] { "id", "cliente_id", "data_atualizacao", "data_fim", "data_inicio", "descricao", "nome", "orcamento", "status" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto A", "Projeto A", 1000000m, 3 },
                    { 2, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto B", "Projeto B", 2000000m, 5 },
                    { 3, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto C", "Projeto C", 3000000m, 10 },
                    { 4, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto D", "Projeto D", 4000000m, 10 },
                    { 5, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto E", "Projeto E", 5000000m, 20 },
                    { 6, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto F", "Projeto F", 6000000m, -1 },
                    { 7, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição do Projeto G", "Projeto G", 9000000m, 20 }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 17, 7 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 19, 4 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 19, 6 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 19, 7 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 20, 5 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 21, 5 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 22, 2 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 22, 6 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 24, 7 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 25, 4 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 27, 7 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 28, 3 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 29, 3 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 32, 4 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 33, 5 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 34, 5 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 35, 5 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 35, 7 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 36, 5 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 36, 7 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 37, 7 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 38, 5 });

            migrationBuilder.DeleteData(
                table: "funcionarios_projetos",
                keyColumns: new[] { "funcionario_id", "projeto_id" },
                keyValues: new object[] { 40, 7 });

            migrationBuilder.DeleteData(
                table: "departamentos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "departamentos",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "departamentos",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "departamentos",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "departamentos",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "funcionarios",
                keyColumn: "id",
                keyValue: 40);

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

            migrationBuilder.DeleteData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "departamentos",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
