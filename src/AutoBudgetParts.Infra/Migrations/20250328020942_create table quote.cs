using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoBudgetParts.Infra.Migrations
{
    /// <inheritdoc />
    public partial class createtablequote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BudgetId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemQuote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    QuoteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemQuote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemQuote_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemQuote_Id",
                table: "ItemQuote",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemQuote_QuoteId",
                table: "ItemQuote",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_BudgetId",
                table: "Quotes",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_Id",
                table: "Quotes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemQuote");

            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
