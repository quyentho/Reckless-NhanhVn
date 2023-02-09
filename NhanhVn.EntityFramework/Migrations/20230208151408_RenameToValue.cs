using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RenameToValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NhanhOrder",
                table: "Orders",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Orders",
                newName: "NhanhOrder");
        }
    }
}
