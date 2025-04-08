using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBudgetMobile.API.Migrations
{
    /// <inheritdoc />
    public partial class Addpasswordandemailtouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: new Guid("57272e05-a899-4c71-8d5e-6496ead7f72e"));

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Surname");

            migrationBuilder.InsertData(
                table: "IncomeSources",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("57272e05-a899-4c71-8d5e-6496ead7f72e"), "This is the first IncomeSource", true, "Salary" });
        }
    }
}
