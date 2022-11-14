using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_CategoryItems_CateoryItemId",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CateoryItemId",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CateoryItemId",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "CatalogItemId",
                schema: "dbo",
                table: "OrderItems",
                newName: "CategoryItemId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(5824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(7470),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(8668));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 29, DateTimeKind.Local).AddTicks(3973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(2846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 29, DateTimeKind.Local).AddTicks(2380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 21, DateTimeKind.Local).AddTicks(7344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 443, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 28, DateTimeKind.Local).AddTicks(9841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 450, DateTimeKind.Local).AddTicks(9065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(9630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 452, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CategoryItemId",
                schema: "dbo",
                table: "OrderItems",
                column: "CategoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_CategoryItems_CategoryItemId",
                schema: "dbo",
                table: "OrderItems",
                column: "CategoryItemId",
                principalSchema: "dbo",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_CategoryItems_CategoryItemId",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CategoryItemId",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "CategoryItemId",
                schema: "dbo",
                table: "OrderItems",
                newName: "CatalogItemId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(7497),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(5824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(8668),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.AddColumn<int>(
                name: "CateoryItemId",
                schema: "dbo",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(3892),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 29, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(6114),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 451, DateTimeKind.Local).AddTicks(1812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 29, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 443, DateTimeKind.Local).AddTicks(4058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 21, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 450, DateTimeKind.Local).AddTicks(9065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 28, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 10, 23, 47, 36, 452, DateTimeKind.Local).AddTicks(1029),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CateoryItemId",
                schema: "dbo",
                table: "OrderItems",
                column: "CateoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_CategoryItems_CateoryItemId",
                schema: "dbo",
                table: "OrderItems",
                column: "CateoryItemId",
                principalSchema: "dbo",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
