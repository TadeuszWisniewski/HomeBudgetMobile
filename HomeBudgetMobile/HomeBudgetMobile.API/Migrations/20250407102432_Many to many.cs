using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBudgetMobile.API.Migrations
{
    /// <inheritdoc />
    public partial class Manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Expenses_ExpenseId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Incomes_IncomeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Savings_SavingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ExpenseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IncomeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SavingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IncomeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SavingId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "ExpenseUser",
                columns: table => new
                {
                    ExpensesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseUser", x => new { x.ExpensesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ExpenseUser_Expenses_ExpensesId",
                        column: x => x.ExpensesId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeUser",
                columns: table => new
                {
                    IncomesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeUser", x => new { x.IncomesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_IncomeUser_Incomes_IncomesId",
                        column: x => x.IncomesId,
                        principalTable: "Incomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingUser",
                columns: table => new
                {
                    SavingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingUser", x => new { x.SavingsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SavingUser_Savings_SavingsId",
                        column: x => x.SavingsId,
                        principalTable: "Savings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavingUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseUser_UsersId",
                table: "ExpenseUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeUser_UsersId",
                table: "IncomeUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingUser_UsersId",
                table: "SavingUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseUser");

            migrationBuilder.DropTable(
                name: "IncomeUser");

            migrationBuilder.DropTable(
                name: "SavingUser");

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IncomeId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SavingId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ExpenseId",
                table: "Users",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IncomeId",
                table: "Users",
                column: "IncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SavingId",
                table: "Users",
                column: "SavingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Expenses_ExpenseId",
                table: "Users",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Incomes_IncomeId",
                table: "Users",
                column: "IncomeId",
                principalTable: "Incomes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Savings_SavingId",
                table: "Users",
                column: "SavingId",
                principalTable: "Savings",
                principalColumn: "Id");
        }
    }
}
