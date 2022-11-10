using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class basket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(9772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 270, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(8144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 218, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 796, DateTimeKind.Local).AddTicks(1946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 271, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 796, DateTimeKind.Local).AddTicks(4240),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 271, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.CreateTable(
                name: "Baskets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 787, DateTimeKind.Local).AddTicks(7937)),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryItemId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(5309)),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalSchema: "dbo",
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_CategoryItems_CategoryItemId",
                        column: x => x.CategoryItemId,
                        principalSchema: "dbo",
                        principalTable: "CategoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                schema: "dbo",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CategoryItemId",
                schema: "dbo",
                table: "BasketItems",
                column: "CategoryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Baskets",
                schema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 270, DateTimeKind.Local).AddTicks(9383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 218, DateTimeKind.Local).AddTicks(804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 271, DateTimeKind.Local).AddTicks(3568),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 796, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 271, DateTimeKind.Local).AddTicks(6992),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 796, DateTimeKind.Local).AddTicks(4240));
        }
    }
}
