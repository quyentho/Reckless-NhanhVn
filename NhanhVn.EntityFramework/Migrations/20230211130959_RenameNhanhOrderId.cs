using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RenameNhanhOrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nhanhorderid",
                table: "orders",
                newName: "nhanhid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nhanhid",
                table: "orders",
                newName: "nhanhorderid");
        }
    }
}
