using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RenameOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Orders",
                table: "Orders",
                newName: "NhanhOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NhanhOrder",
                table: "Orders",
                newName: "Orders");
        }
    }
}
