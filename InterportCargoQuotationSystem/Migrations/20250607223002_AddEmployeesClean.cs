using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterportCargoQuotationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeesClean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeType = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

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
    }
}
