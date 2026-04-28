using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GaSoft.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedFuncionarioDetalhe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "funcionario_detalhes",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "funcionario_detalhes",
                keyColumn: "id",
                keyValue: 45);
        }
    }
}
