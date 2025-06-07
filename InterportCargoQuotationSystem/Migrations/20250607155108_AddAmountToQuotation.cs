using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterportCargoQuotationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddAmountToQuotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateIssued",
                table: "Quotations",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<bool>(
                name: "DiscountApplied",
                table: "Quotations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Quotations",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Quotations");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Quotations",
                newName: "DateIssued");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountApplied",
                table: "Quotations",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");
        }
    }
}
