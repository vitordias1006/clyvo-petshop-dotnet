using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetshopApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "RAW(900)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    TargetSpecies = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ImgUrl = table.Column<string>(type: "NVARCHAR2(180)", maxLength: 180, nullable: false),
                    Active = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "RAW(900)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "NVARCHAR2(13)", maxLength: 13, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "RAW(900)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DiscountApplied = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    CrateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    UserId = table.Column<byte[]>(type: "RAW(900)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDERS_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PETS",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "RAW(900)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Species = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Race = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Weight = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    UserId = table.Column<byte[]>(type: "RAW(900)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PETS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PETS_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SIGNATURES",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "RAW(900)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UserId = table.Column<byte[]>(type: "RAW(900)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIGNATURES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIGNATURES_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Quantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    OrderId = table.Column<byte[]>(type: "RAW(900)", nullable: false),
                    ProductId = table.Column<byte[]>(type: "RAW(900)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOrders_ORDERS_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrders_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEDICAL_FILES",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "RAW(900)", nullable: false),
                    Allergies = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    ChronicDiseases = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Medicines = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    LastVaccine = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NextVaccine = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Obs = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    PetId = table.Column<byte[]>(type: "RAW(900)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICAL_FILES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MEDICAL_FILES_PETS_PetId",
                        column: x => x.PetId,
                        principalTable: "PETS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QUERIES",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "RAW(900)", nullable: false),
                    Time = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Obs = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    PetId = table.Column<byte[]>(type: "RAW(900)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUERIES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUERIES_PETS_PetId",
                        column: x => x.PetId,
                        principalTable: "PETS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLAN_DATAS",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "RAW(900)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    MonthlyPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ConsultationsMonth = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    MktDiscount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    Benefits = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    Active = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false),
                    SignatureId = table.Column<byte[]>(type: "RAW(900)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAN_DATAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PLAN_DATAS_SIGNATURES_SignatureId",
                        column: x => x.SignatureId,
                        principalTable: "SIGNATURES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_OrderId",
                table: "ItemOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_ProductId",
                table: "ItemOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICAL_FILES_PetId",
                table: "MEDICAL_FILES",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_UserId",
                table: "ORDERS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PETS_UserId",
                table: "PETS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_DATAS_SignatureId",
                table: "PLAN_DATAS",
                column: "SignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_QUERIES_PetId",
                table: "QUERIES",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_SIGNATURES_UserId",
                table: "SIGNATURES",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemOrders");

            migrationBuilder.DropTable(
                name: "MEDICAL_FILES");

            migrationBuilder.DropTable(
                name: "PLAN_DATAS");

            migrationBuilder.DropTable(
                name: "QUERIES");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "SIGNATURES");

            migrationBuilder.DropTable(
                name: "PETS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
