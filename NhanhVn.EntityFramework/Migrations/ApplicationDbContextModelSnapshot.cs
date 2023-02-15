﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NhanhVn.EntityFramework;
using NhanhVn.EntityFramework.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NhanhVn.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NhanhVn.Common.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("CategoryId")
                        .HasColumnType("text")
                        .HasColumnName("category_id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("ParentId")
                        .HasColumnType("text")
                        .HasColumnName("parent_id");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_categories_category_id");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("NhanhVn.EntityFramework.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("CalcTotalMoney")
                        .HasColumnType("double precision")
                        .HasColumnName("calc_total_money");

                    b.Property<int?>("CarrierId")
                        .HasColumnType("integer")
                        .HasColumnName("carrier_id");

                    b.Property<string>("CarrierName")
                        .HasColumnType("text")
                        .HasColumnName("carrier_name");

                    b.Property<int>("CodFee")
                        .HasColumnType("integer")
                        .HasColumnName("cod_fee");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date_time");

                    b.Property<string>("CustomerCity")
                        .HasColumnType("text")
                        .HasColumnName("customer_city");

                    b.Property<int?>("CustomerCityId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_city_id");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<string>("CustomerMobile")
                        .HasColumnType("text")
                        .HasColumnName("customer_mobile");

                    b.Property<int>("CustomerShipFee")
                        .HasColumnType("integer")
                        .HasColumnName("customer_ship_fee");

                    b.Property<int>("DeclaredFee")
                        .HasColumnType("integer")
                        .HasColumnName("declared_fee");

                    b.Property<string>("DeliveryDate")
                        .HasColumnType("text")
                        .HasColumnName("delivery_date");

                    b.Property<int?>("DepotId")
                        .HasColumnType("integer")
                        .HasColumnName("depot_id");

                    b.Property<string>("DepotName")
                        .HasColumnType("text")
                        .HasColumnName("depot_name");

                    b.Property<string>("MerchantTrackingNumber")
                        .HasColumnType("text")
                        .HasColumnName("merchant_tracking_number");

                    b.Property<double>("MoneyDeposit")
                        .HasColumnType("double precision")
                        .HasColumnName("money_deposit");

                    b.Property<double>("MoneyDiscount")
                        .HasColumnType("double precision")
                        .HasColumnName("money_discount");

                    b.Property<double>("MoneyTransfer")
                        .HasColumnType("double precision")
                        .HasColumnName("money_transfer");

                    b.Property<int>("NhanhId")
                        .HasColumnType("integer")
                        .HasColumnName("nhanh_id");

                    b.Property<int>("OverWeightShipFee")
                        .HasColumnType("integer")
                        .HasColumnName("over_weight_ship_fee");

                    b.Property<List<OrderProduct>>("Products")
                        .HasColumnType("jsonb")
                        .HasColumnName("products");

                    b.Property<int>("ReturnFee")
                        .HasColumnType("integer")
                        .HasColumnName("return_fee");

                    b.Property<string>("SaleChannel")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("sale_channel");

                    b.Property<int>("ShipFee")
                        .HasColumnType("integer")
                        .HasColumnName("ship_fee");

                    b.Property<string>("StatusCode")
                        .HasColumnType("text")
                        .HasColumnName("status_code");

                    b.Property<string>("StatusName")
                        .HasColumnType("text")
                        .HasColumnName("status_name");

                    b.Property<string>("Type")
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<int?>("TypeId")
                        .HasColumnType("integer")
                        .HasColumnName("type_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("NhanhVn.EntityFramework.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("AvgCost")
                        .HasColumnType("double precision")
                        .HasColumnName("avg_cost");

                    b.Property<string>("Barcode")
                        .HasColumnType("text")
                        .HasColumnName("barcode");

                    b.Property<string>("CategoryId")
                        .HasColumnType("text")
                        .HasColumnName("category_id");

                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("CreatedDateTime")
                        .HasColumnType("text")
                        .HasColumnName("created_date_time");

                    b.Property<string>("IdNhanh")
                        .HasColumnType("text")
                        .HasColumnName("id_nhanh");

                    b.Property<string>("ImportPrice")
                        .HasColumnType("text")
                        .HasColumnName("import_price");

                    b.Property<ProductInventory>("Inventory")
                        .HasColumnType("jsonb")
                        .HasColumnName("inventory");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("ParentId")
                        .HasColumnType("text")
                        .HasColumnName("parent_id");

                    b.Property<double?>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("TypeId")
                        .HasColumnType("text")
                        .HasColumnName("type_id");

                    b.Property<string>("TypeName")
                        .HasColumnType("text")
                        .HasColumnName("type_name");

                    b.Property<string>("Unit")
                        .HasColumnType("text")
                        .HasColumnName("unit");

                    b.Property<double?>("Vat")
                        .HasColumnType("double precision")
                        .HasColumnName("vat");

                    b.Property<double?>("WholesalePrice")
                        .HasColumnType("double precision")
                        .HasColumnName("wholesale_price");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("NhanhVn.Common.Models.Category", b =>
                {
                    b.HasOne("NhanhVn.Common.Models.Category", null)
                        .WithMany("Childs")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_categories_categories_category_id");
                });

            modelBuilder.Entity("NhanhVn.Common.Models.Category", b =>
                {
                    b.Navigation("Childs");
                });
#pragma warning restore 612, 618
        }
    }
}
