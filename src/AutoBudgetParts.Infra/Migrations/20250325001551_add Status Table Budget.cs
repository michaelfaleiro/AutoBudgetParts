using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoBudgetParts.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addStatusTableBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Budget",
                type: "VARCHAR",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Budget");
        }
    }
}
