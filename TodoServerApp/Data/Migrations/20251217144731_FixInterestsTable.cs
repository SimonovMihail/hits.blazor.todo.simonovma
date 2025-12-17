using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoServerApp.Migrations
{
    /// <inheritdoc />
    public partial class FixInterestsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestProfile_Interest_InterestsId",
                table: "InterestProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interest",
                table: "Interest");

            migrationBuilder.RenameTable(
                name: "Interest",
                newName: "Interests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interests",
                table: "Interests",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastActive",
                value: new DateTime(2025, 10, 17, 19, 47, 30, 955, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastActive",
                value: new DateTime(2025, 12, 10, 19, 47, 30, 955, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastActive",
                value: new DateTime(2025, 12, 16, 22, 47, 30, 955, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.AddForeignKey(
                name: "FK_InterestProfile_Interests_InterestsId",
                table: "InterestProfile",
                column: "InterestsId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestProfile_Interests_InterestsId",
                table: "InterestProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interests",
                table: "Interests");

            migrationBuilder.RenameTable(
                name: "Interests",
                newName: "Interest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interest",
                table: "Interest",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastActive",
                value: new DateTime(2025, 10, 17, 19, 17, 42, 948, DateTimeKind.Local).AddTicks(6945));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastActive",
                value: new DateTime(2025, 12, 10, 19, 17, 42, 948, DateTimeKind.Local).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastActive",
                value: new DateTime(2025, 12, 16, 22, 17, 42, 948, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.AddForeignKey(
                name: "FK_InterestProfile_Interest_InterestsId",
                table: "InterestProfile",
                column: "InterestsId",
                principalTable: "Interest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
