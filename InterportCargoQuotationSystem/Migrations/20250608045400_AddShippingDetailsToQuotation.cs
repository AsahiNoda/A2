using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterportCargoQuotationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingDetailsToQuotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationCountry",
                table: "Quotations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginCountry",
                table: "Quotations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PackageHeight",
                table: "Quotations",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PackageType",
                table: "Quotations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PackageWidth",
                table: "Quotations",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationCountry",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "OriginCountry",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "PackageHeight",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "PackageType",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "PackageWidth",
                table: "Quotations");
        }
    }
}
