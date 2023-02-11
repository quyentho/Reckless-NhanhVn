﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NhanhVn.Common.Models;
using NhanhVn.EntityFramework;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230211131946_ChangeMoneyTypeToDouble")]
    partial class ChangeMoneyTypeToDouble
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameworkWithPostgresPOC.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("CalcTotalMoney")
                        .HasColumnType("double precision")
                        .HasColumnName("calctotalmoney");

                    b.Property<int?>("CarrierId")
                        .HasColumnType("integer")
                        .HasColumnName("carrierid");

                    b.Property<string>("CarrierName")
                        .HasColumnType("text")
                        .HasColumnName("carriername");

                    b.Property<int?>("CodFee")
                        .HasColumnType("integer")
                        .HasColumnName("codfee");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createddatetime");

                    b.Property<string>("CustomerCity")
                        .HasColumnType("text")
                        .HasColumnName("customercity");

                    b.Property<int?>("CustomerCityId")
                        .HasColumnType("integer")
                        .HasColumnName("customercityid");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customerid");

                    b.Property<string>("CustomerMobile")
                        .HasColumnType("text")
                        .HasColumnName("customermobile");

                    b.Property<int?>("CustomerShipFee")
                        .HasColumnType("integer")
                        .HasColumnName("customershipfee");

                    b.Property<int?>("DeclaredFee")
                        .HasColumnType("integer")
                        .HasColumnName("declaredfee");

                    b.Property<string>("DeliveryDate")
                        .HasColumnType("text")
                        .HasColumnName("deliverydate");

                    b.Property<int?>("DepotId")
                        .HasColumnType("integer")
                        .HasColumnName("depotid");

                    b.Property<string>("DepotName")
                        .HasColumnType("text")
                        .HasColumnName("depotname");

                    b.Property<string>("MerchantTrackingNumber")
                        .HasColumnType("text")
                        .HasColumnName("merchanttrackingnumber");

                    b.Property<double?>("MoneyDeposit")
                        .HasColumnType("double precision")
                        .HasColumnName("moneydeposit");

                    b.Property<double?>("MoneyDiscount")
                        .HasColumnType("double precision")
                        .HasColumnName("moneydiscount");

                    b.Property<double?>("MoneyTransfer")
                        .HasColumnType("double precision")
                        .HasColumnName("moneytransfer");

                    b.Property<int>("NhanhId")
                        .HasColumnType("integer")
                        .HasColumnName("nhanhid");

                    b.Property<int?>("OverWeightShipFee")
                        .HasColumnType("integer")
                        .HasColumnName("overweightshipfee");

                    b.Property<List<NhanhOrderProduct>>("Products")
                        .HasColumnType("jsonb")
                        .HasColumnName("products");

                    b.Property<int?>("ReturnFee")
                        .HasColumnType("integer")
                        .HasColumnName("returnfee");

                    b.Property<int?>("SaleChannel")
                        .HasColumnType("integer")
                        .HasColumnName("salechannel");

                    b.Property<int?>("ShipFee")
                        .HasColumnType("integer")
                        .HasColumnName("shipfee");

                    b.Property<string>("StatusCode")
                        .HasColumnType("text")
                        .HasColumnName("statuscode");

                    b.Property<string>("StatusName")
                        .HasColumnType("text")
                        .HasColumnName("statusname");

                    b.Property<string>("Type")
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<int?>("TypeId")
                        .HasColumnType("integer")
                        .HasColumnName("typeid");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.ToTable("orders", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
