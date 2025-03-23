using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoBudgetParts.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientName = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    CarModel = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    CarPlate = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: false),
                    CarVin = table.Column<string>(type: "VARCHAR", maxLength: 17, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemBudget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sku = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    Brand = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    Approved = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BudgetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBudget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBudget_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_CarPlate",
                table: "Budget",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_Id",
                table: "Budget",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBudget_BudgetId",
                table: "ItemBudget",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBudget_Id",
                table: "ItemBudget",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemBudget");

            migrationBuilder.DropTable(
                name: "Budget");
        }
    }
}
