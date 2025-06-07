using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterportCargoQuotationSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    DateIssued = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ContainerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiresQuarantine = table.Column<bool>(type: "INTEGER", nullable: false),
                    RequiresFumigation = table.Column<bool>(type: "INTEGER", nullable: false),
                    BasePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountApplied = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerFeedback = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotations");
        }
    }
}
