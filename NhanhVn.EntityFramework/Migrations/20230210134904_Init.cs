using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using NhanhVn.Common.Models;
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
                    salechannel = table.Column<int>(type: "integer", nullable: true),
                    merchanttrackingnumber = table.Column<string>(type: "text", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    depotid = table.Column<int>(type: "integer", nullable: true),
                    depotname = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    typeid = table.Column<int>(type: "integer", nullable: true),
                    moneydiscount = table.Column<int>(type: "integer", nullable: true),
                    moneydeposit = table.Column<int>(type: "integer", nullable: true),
                    moneytransfer = table.Column<int>(type: "integer", nullable: true),
                    carrierid = table.Column<int>(type: "integer", nullable: true),
                    carriername = table.Column<string>(type: "text", nullable: true),
                    shipfee = table.Column<int>(type: "integer", nullable: true),
                    codfee = table.Column<int>(type: "integer", nullable: true),
                    customershipfee = table.Column<int>(type: "integer", nullable: true),
                    returnfee = table.Column<int>(type: "integer", nullable: true),
                    overweightshipfee = table.Column<int>(type: "integer", nullable: true),
                    declaredfee = table.Column<int>(type: "integer", nullable: true),
                    customerid = table.Column<int>(type: "integer", nullable: true),
                    customermobile = table.Column<string>(type: "text", nullable: true),
                    customercityid = table.Column<int>(type: "integer", nullable: true),
                    customercity = table.Column<string>(type: "text", nullable: true),
                    deliverydate = table.Column<string>(type: "text", nullable: true),
                    statusname = table.Column<string>(type: "text", nullable: true),
                    statuscode = table.Column<string>(type: "text", nullable: true),
                    calctotalmoney = table.Column<int>(type: "integer", nullable: true),
                    products = table.Column<List<NhanhProduct>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
