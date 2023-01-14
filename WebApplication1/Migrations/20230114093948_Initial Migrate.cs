using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategory1",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory1", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategory1_ProductCategory1_ParentProductCategoryId",
                        column: x => x.ParentProductCategoryId,
                        principalTable: "ProductCategory1",
                        principalColumn: "ProductCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                columns: table => new
                {
                    ProductDescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.ProductDescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel1",
                columns: table => new
                {
                    ProductModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel1", x => x.ProductModelId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductModelId = table.Column<int>(type: "int", nullable: true),
                    SellStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThumbNailPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ThumbnailPhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory1_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory1",
                        principalColumn: "ProductCategoryId");
                    table.ForeignKey(
                        name: "FK_Product_ProductModel1_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "ProductModel1",
                        principalColumn: "ProductModelId");
                });

            migrationBuilder.CreateTable(
                name: "ProductModelProductDescription",
                columns: table => new
                {
                    ProductModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDescriptionId = table.Column<int>(type: "int", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductModelId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelProductDescription", x => x.ProductModelId);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescription_ProductDescription_ProductDescriptionId",
                        column: x => x.ProductDescriptionId,
                        principalTable: "ProductDescription",
                        principalColumn: "ProductDescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescription_ProductModel1_ProductModelId1",
                        column: x => x.ProductModelId1,
                        principalTable: "ProductModel1",
                        principalColumn: "ProductModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductModelId = table.Column<int>(type: "int", nullable: true),
                    SellStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThumbNailPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ThumbnailPhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory1_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory1",
                        principalColumn: "ProductCategoryId");
                    table.ForeignKey(
                        name: "FK_Products_ProductModel1_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "ProductModel1",
                        principalColumn: "ProductModelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductModelId",
                table: "Product",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory1_ParentProductCategoryId",
                table: "ProductCategory1",
                column: "ParentProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescription_ProductDescriptionId",
                table: "ProductModelProductDescription",
                column: "ProductDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescription_ProductModelId1",
                table: "ProductModelProductDescription",
                column: "ProductModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductModelId",
                table: "Products",
                column: "ProductModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductModelProductDescription");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductDescription");

            migrationBuilder.DropTable(
                name: "ProductCategory1");

            migrationBuilder.DropTable(
                name: "ProductModel1");
        }
    }
}
