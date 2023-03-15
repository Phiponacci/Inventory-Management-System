using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ims.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Operation = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitOfMeasureName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Isocode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ToStoreId = table.Column<int>(type: "int", nullable: true),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Store_ToStoreId",
                        column: x => x.ToStoreId,
                        principalTable: "Store",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreStock",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreStock", x => new { x.StoreId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_StoreStock_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreStock_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetail",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetail", x => new { x.TransactionId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreateDate", "Module", "Operation" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(2493), "User", "VIEW" },
                    { 2, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(4057), "User", "CREATE" },
                    { 3, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(4770), "User", "UPDATE" },
                    { 4, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(4829), "User", "DELETE" },
                    { 5, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5244), "Role", "VIEW" },
                    { 6, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5289), "Role", "CREATE" },
                    { 7, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5304), "Role", "UPDATE" },
                    { 8, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5319), "Role", "DELETE" },
                    { 9, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5392), "Stock", "VIEW" },
                    { 10, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5408), "Stock", "CREATE" },
                    { 11, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5422), "Stock", "UPDATE" },
                    { 12, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5435), "Stock", "DELETE" },
                    { 13, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5546), "Report", "VIEW" },
                    { 14, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5563), "Report", "CREATE" },
                    { 15, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5577), "Report", "UPDATE" },
                    { 16, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5590), "Report", "DELETE" },
                    { 17, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5618), "Product", "VIEW" },
                    { 18, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5632), "Product", "CREATE" },
                    { 19, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5646), "Product", "UPDATE" },
                    { 20, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5659), "Product", "DELETE" },
                    { 21, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5686), "Transaction", "VIEW" },
                    { 22, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5700), "Transaction", "CREATE" },
                    { 23, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5713), "Transaction", "UPDATE" },
                    { 24, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5727), "Transaction", "DELETE" },
                    { 25, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5829), "Store", "VIEW" },
                    { 26, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5855), "Store", "CREATE" },
                    { 27, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5878), "Store", "UPDATE" },
                    { 28, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5902), "Store", "DELETE" },
                    { 29, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5955), "Category", "VIEW" },
                    { 30, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5970), "Category", "CREATE" },
                    { 31, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5983), "Category", "UPDATE" },
                    { 32, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(5997), "Category", "DELETE" },
                    { 33, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(6023), "UnitOfMesure", "VIEW" },
                    { 34, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(6038), "UnitOfMesure", "CREATE" },
                    { 35, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(6051), "UnitOfMesure", "UPDATE" },
                    { 36, new DateTime(2023, 3, 15, 14, 7, 42, 946, DateTimeKind.Local).AddTicks(6073), "UnitOfMesure", "DELETE" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateDate", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 15, 14, 7, 42, 909, DateTimeKind.Local).AddTicks(439), "Admin" },
                    { 2, new DateTime(2023, 3, 15, 14, 7, 42, 910, DateTimeKind.Local).AddTicks(9714), "Accountant" },
                    { 3, new DateTime(2023, 3, 15, 14, 7, 42, 910, DateTimeKind.Local).AddTicks(9733), "Driver" }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "CreateDate", "StoreCode", "StoreName" },
                values: new object[] { 1, new DateTime(2023, 3, 15, 14, 7, 43, 388, DateTimeKind.Local).AddTicks(7924), "EX01", "Example Store" });

            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "Id", "CreateDate", "TransactionTypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 15, 14, 7, 43, 388, DateTimeKind.Local).AddTicks(7717), "Stock Receipt" },
                    { 2, new DateTime(2023, 3, 15, 14, 7, 43, 388, DateTimeKind.Local).AddTicks(7719), "Stock Out" },
                    { 3, new DateTime(2023, 3, 15, 14, 7, 43, 388, DateTimeKind.Local).AddTicks(7721), "Transfer" }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasure",
                columns: new[] { "Id", "CreateDate", "Isocode", "UnitOfMeasureName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 15, 14, 7, 43, 388, DateTimeKind.Local).AddTicks(7820), "pc", "Piece" },
                    { 2, new DateTime(2023, 3, 15, 14, 7, 43, 388, DateTimeKind.Local).AddTicks(7828), "kg", "Kilogram" },
                    { 3, new DateTime(2023, 3, 15, 14, 7, 43, 388, DateTimeKind.Local).AddTicks(7833), "m", "Meter" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 1, new DateTime(2023, 3, 15, 14, 7, 42, 948, DateTimeKind.Local).AddTicks(8111), null, null, null, "1b2ebfa84ad4d06eed294bc9b79c51cbab7c1e203a39b86395d4f5ac28807a00", null, "Admin" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Barcode", "CategoryId", "CreateDate", "Description", "Image", "Price", "ProductName", "UnitOfMeasureId" },
                values: new object[] { 1, "EX01", null, new DateTime(2023, 3, 15, 14, 7, 43, 388, DateTimeKind.Local).AddTicks(8021), null, null, 1m, "Example Product", 1 });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 27, 1 },
                    { 28, 1 },
                    { 29, 1 },
                    { 30, 1 },
                    { 31, 1 },
                    { 32, 1 },
                    { 33, 1 },
                    { 34, 1 },
                    { 35, 1 },
                    { 36, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Module_Operation",
                table: "Permission",
                columns: new[] { "Module", "Operation" },
                unique: true,
                filter: "[Module] IS NOT NULL AND [Operation] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitOfMeasureId",
                table: "Product",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleName",
                table: "Role",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreStock_ProductId",
                table: "StoreStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_StoreId",
                table: "Transaction",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ToStoreId",
                table: "Transaction",
                column: "ToStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_ProductId",
                table: "TransactionDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "StoreStock");

            migrationBuilder.DropTable(
                name: "TransactionDetail");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "TransactionType");
        }
    }
}
