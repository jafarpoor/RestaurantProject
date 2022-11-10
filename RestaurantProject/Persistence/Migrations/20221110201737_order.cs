using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(3892),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 120, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(6114),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 121, DateTimeKind.Local).AddTicks(5179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(1812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 120, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 443, DateTimeKind.Local).AddTicks(4058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 94, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 450, DateTimeKind.Local).AddTicks(9065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 119, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 452, DateTimeKind.Local).AddTicks(1029),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 122, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CateoryItemId = table.Column<int>(type: "int", nullable: true),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(8668)),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_CategoryItems_CateoryItemId",
                        column: x => x.CateoryItemId,
                        principalSchema: "dbo",
                        principalTable: "CategoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(7497)),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CateoryItemId",
                schema: "dbo",
                table: "OrderItems",
                column: "CateoryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 120, DateTimeKind.Local).AddTicks(9622),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 121, DateTimeKind.Local).AddTicks(5179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 120, DateTimeKind.Local).AddTicks(5180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 94, DateTimeKind.Local).AddTicks(1872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 443, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 119, DateTimeKind.Local).AddTicks(7616),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 450, DateTimeKind.Local).AddTicks(9065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 122, DateTimeKind.Local).AddTicks(1240),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 452, DateTimeKind.Local).AddTicks(1029));
        }
    }
}
