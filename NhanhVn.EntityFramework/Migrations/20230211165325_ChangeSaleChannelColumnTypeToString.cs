using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSaleChannelColumnTypeToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "salechannel",
                table: "orders",
                type: "VARCHAR",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "salechannel",
                table: "orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
