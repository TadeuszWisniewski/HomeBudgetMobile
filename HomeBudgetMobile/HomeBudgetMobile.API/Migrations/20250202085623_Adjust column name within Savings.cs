using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBudgetMobile.API.Migrations
{
    /// <inheritdoc />
    public partial class AdjustcolumnnamewithinSavings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amound",
                table: "Savings",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Savings",
                newName: "Amound");
        }
    }
}
