using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoBudgetParts.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddObservationonTableBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Budget",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Budget");
        }
    }
}
