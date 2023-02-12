using Microsoft.EntityFrameworkCore.Migrations;
using NhanhVn.EntityFramework.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idnhanh = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    barcode = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    parentid = table.Column<string>(type: "text", nullable: true),
                    typeid = table.Column<string>(type: "text", nullable: true),
                    typename = table.Column<string>(type: "text", nullable: true),
                    avgcost = table.Column<double>(type: "double precision", nullable: true),
                    categoryid = table.Column<string>(type: "text", nullable: true),
                    importprice = table.Column<string>(type: "text", nullable: true),
                    wholesaleprice = table.Column<double>(type: "double precision", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    vat = table.Column<double>(type: "double precision", nullable: true),
                    createddatetime = table.Column<string>(type: "text", nullable: true),
                    inventory = table.Column<ProductInventory>(type: "jsonb", nullable: true),
                    unit = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
