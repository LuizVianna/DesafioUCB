using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UCB.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Serie = table.Column<int>(type: "int", nullable: false),
                    NotaMedia = table.Column<double>(type: "float", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "DataNascimento", "Endereco", "Idade", "Nome", "NomeMae", "NomePai", "NotaMedia", "Serie" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua x, nº 120 - Campo Grande - Rio de Janeiro - RJ - 23000-000", 14, "Luciana Souza", "Maria de Lourdes de Souza", "Jorge Alves de Souza", 9.5, 9 },
                    { 2, new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua y, nº 230 - Campo Grande - Rio de Janeiro - RJ - 23000-000", 6, "Débora Soares", "Rita Soares", "Paulo Nogueira", 8.5, 1 },
                    { 3, new DateTime(2016, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua w, nº 530 - Campo Grande - Rio de Janeiro - RJ - 23000-000", 7, "Melissa Peixoto", "Rose Peixoto", "Rogério Felix", 8.5, 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "admin", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
