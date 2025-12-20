using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriReachWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FarmersMarketLocation",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmersMarketLocation", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "FarmersMarkets",
                columns: table => new
                {
                    MarketID = table.Column<int>(type: "int", nullable: false),
                    MarketName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    AreaID = table.Column<int>(type: "int", nullable: false),
                    OpeningDays = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmersMarkets", x => x.MarketID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false),
                    ProductCategoryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Role = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCAC1C3D57EF", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaID = table.Column<int>(type: "int", nullable: false),
                    AreaName = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaID);
                    table.ForeignKey(
                        name: "FK_Areas_Areas",
                        column: x => x.LocationID,
                        principalTable: "FarmersMarketLocation",
                        principalColumn: "LocationID");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Unit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Produces = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__B40CC6ED86EE0BBE", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory1",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderID = table.Column<int>(type: "int", nullable: false),
                    ReceiverID = table.Column<int>(type: "int", nullable: false),
                    MessageText = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Messages__C87C037C93E012BE", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_Receiver",
                        column: x => x.ReceiverID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Messages_Sender",
                        column: x => x.SenderID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    ListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shopping__E38328659E5A72EB", x => x.ListID);
                    table.ForeignKey(
                        name: "FK_ShoppingList_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    FarmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FarmName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                        .Annotation("Relational:DefaultConstraintName", "DF__Farms__DateRegis__75A278F5"),
                    AreaID = table.Column<int>(type: "int", nullable: true),
                    Parish = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Produces = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Product = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Farms__ED7BBA995F83201E", x => x.FarmID);
                    table.ForeignKey(
                        name: "FK_Farms_Users",
                        column: x => x.AreaID,
                        principalTable: "Areas",
                        principalColumn: "AreaID");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shopping__727E83EB182B8C6B", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_List",
                        column: x => x.ListID,
                        principalTable: "ShoppingList",
                        principalColumn: "ListID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_Product",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmProducts",
                columns: table => new
                {
                    FarmProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AvailabilityStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                        .Annotation("Relational:DefaultConstraintName", "DF__FarmProdu__LastU__7D439ABD"),
                    Unit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FarmProd__0065724677D12861", x => x.FarmProductID);
                    table.ForeignKey(
                        name: "FK_FarmProducts_Farm",
                        column: x => x.FarmID,
                        principalTable: "Farms",
                        principalColumn: "FarmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmProducts_Product",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FarmID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DatePosted = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reviews__74BC79AE6CE73538", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Farm",
                        column: x => x.FarmID,
                        principalTable: "Farms",
                        principalColumn: "FarmID");
                    table.ForeignKey(
                        name: "FK_Reviews_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_LocationID",
                table: "Areas",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_FarmProducts_FarmID",
                table: "FarmProducts",
                column: "FarmID");

            migrationBuilder.CreateIndex(
                name: "IX_FarmProducts_ProductID",
                table: "FarmProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_AreaID",
                table: "Farms",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverID",
                table: "Messages",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderID",
                table: "Messages",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryID",
                table: "Products",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FarmID",
                table: "Reviews",
                column: "FarmID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserID",
                table: "Reviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_UserID",
                table: "ShoppingList",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ListID",
                table: "ShoppingListItems",
                column: "ListID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ProductID",
                table: "ShoppingListItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D105342A65C7FB",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmersMarkets");

            migrationBuilder.DropTable(
                name: "FarmProducts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShoppingListItems");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "FarmersMarketLocation");
        }
    }
}
