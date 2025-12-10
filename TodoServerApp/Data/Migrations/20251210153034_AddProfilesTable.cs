using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoServerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Age", "Bio", "City", "LastActive", "Name" },
                values: new object[,]
                {
                    { 1, 19, "Ищу крутого", "Когалым", new DateTime(2025, 10, 10, 20, 30, 33, 510, DateTimeKind.Local).AddTicks(8742), "Катя" },
                    { 2, 21, "Ищу игрока в покер", "Артёмовск", new DateTime(2025, 12, 3, 20, 30, 33, 510, DateTimeKind.Local).AddTicks(8789), "Димитрий" },
                    { 3, 23, "Хожу в качалку", "Тюмень", new DateTime(2025, 12, 9, 23, 30, 33, 510, DateTimeKind.Local).AddTicks(8796), "Егор" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
