using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using NhanhVn.EntityFramework.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nhanhid = table.Column<int>(name: "nhanh_id", type: "integer", nullable: false),
                    salechannel = table.Column<string>(name: "sale_channel", type: "VARCHAR", maxLength: 20, nullable: true),
                    merchanttrackingnumber = table.Column<string>(name: "merchant_tracking_number", type: "text", nullable: true),
                    createddatetime = table.Column<DateTime>(name: "created_date_time", type: "timestamp with time zone", nullable: false),
                    depotid = table.Column<int>(name: "depot_id", type: "integer", nullable: true),
                    depotname = table.Column<string>(name: "depot_name", type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    typeid = table.Column<int>(name: "type_id", type: "integer", nullable: true),
                    moneydiscount = table.Column<double>(name: "money_discount", type: "double precision", nullable: false),
                    moneydeposit = table.Column<double>(name: "money_deposit", type: "double precision", nullable: false),
                    moneytransfer = table.Column<double>(name: "money_transfer", type: "double precision", nullable: false),
                    carrierid = table.Column<int>(name: "carrier_id", type: "integer", nullable: true),
                    carriername = table.Column<string>(name: "carrier_name", type: "text", nullable: true),
                    shipfee = table.Column<int>(name: "ship_fee", type: "integer", nullable: false),
                    codfee = table.Column<int>(name: "cod_fee", type: "integer", nullable: false),
                    customershipfee = table.Column<int>(name: "customer_ship_fee", type: "integer", nullable: false),
                    returnfee = table.Column<int>(name: "return_fee", type: "integer", nullable: false),
                    overweightshipfee = table.Column<int>(name: "over_weight_ship_fee", type: "integer", nullable: false),
                    declaredfee = table.Column<int>(name: "declared_fee", type: "integer", nullable: false),
                    customerid = table.Column<int>(name: "customer_id", type: "integer", nullable: true),
                    customermobile = table.Column<string>(name: "customer_mobile", type: "text", nullable: true),
                    customercityid = table.Column<int>(name: "customer_city_id", type: "integer", nullable: true),
                    customercity = table.Column<string>(name: "customer_city", type: "text", nullable: true),
                    deliverydate = table.Column<string>(name: "delivery_date", type: "text", nullable: true),
                    statusname = table.Column<string>(name: "status_name", type: "text", nullable: true),
                    statuscode = table.Column<string>(name: "status_code", type: "text", nullable: true),
                    calctotalmoney = table.Column<double>(name: "calc_total_money", type: "double precision", nullable: false),
                    products = table.Column<List<OrderProduct>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idnhanh = table.Column<string>(name: "id_nhanh", type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    barcode = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    parentid = table.Column<string>(name: "parent_id", type: "text", nullable: true),
                    typeid = table.Column<string>(name: "type_id", type: "text", nullable: true),
                    typename = table.Column<string>(name: "type_name", type: "text", nullable: true),
                    avgcost = table.Column<double>(name: "avg_cost", type: "double precision", nullable: true),
                    categoryid = table.Column<string>(name: "category_id", type: "text", nullable: true),
                    importprice = table.Column<string>(name: "import_price", type: "text", nullable: true),
                    wholesaleprice = table.Column<double>(name: "wholesale_price", type: "double precision", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    vat = table.Column<double>(type: "double precision", nullable: true),
                    createddatetime = table.Column<string>(name: "created_date_time", type: "text", nullable: true),
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
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
