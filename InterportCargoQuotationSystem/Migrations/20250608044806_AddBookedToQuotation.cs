using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterportCargoQuotationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddBookedToQuotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Booked",
                table: "Quotations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Booked",
                table: "Quotations");
        }
    }
}
