using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddPreDiscountColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "prediscount",
                table: "orders",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prediscount",
                table: "orders");
        }
    }
}
