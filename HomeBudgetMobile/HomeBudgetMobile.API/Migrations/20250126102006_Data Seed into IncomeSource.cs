using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBudgetMobile.API.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedintoIncomeSource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "IncomeSource",
                columns: new[] { "Id", "Active", "Description", "Name" },
                values: new object[] { 0, true, null, "Salary" });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_IdExpenseSort",
                table: "Expense",
                column: "IdExpenseSort");

            migrationBuilder.CreateIndex(
                name: "IX_Expense-User_IdExpense",
                table: "Expense-User",
                column: "IdExpense");

            migrationBuilder.CreateIndex(
                name: "IX_Expense-User_IdUser",
                table: "Expense-User",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Income_IdIncomeSource",
                table: "Income",
                column: "IdIncomeSource");

            migrationBuilder.CreateIndex(
                name: "IX_User-Income_IdIncome",
                table: "User-Income",
                column: "IdIncome");

            migrationBuilder.CreateIndex(
                name: "IX_User-Income_IdUser",
                table: "User-Income",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users-Savings_IdSavings",
                table: "Users-Savings",
                column: "IdSavings");

            migrationBuilder.CreateIndex(
                name: "IX_Users-Savings_IdUser",
                table: "Users-Savings",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense-User");

            migrationBuilder.DropTable(
                name: "User-Income");

            migrationBuilder.DropTable(
                name: "Users-Savings");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Savings");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ExpenseSort");

            migrationBuilder.DropTable(
                name: "IncomeSource");
        }
    }
}
