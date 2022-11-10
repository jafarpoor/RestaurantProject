using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_CatalogItemImages_CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogItemImages",
                schema: "dbo",
                table: "CatalogItemImages");

            migrationBuilder.RenameTable(
                name: "CatalogItemImages",
                schema: "dbo",
                newName: "CategoryItemImages",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 472, DateTimeKind.Local).AddTicks(7519),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 472, DateTimeKind.Local).AddTicks(4553),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 459, DateTimeKind.Local).AddTicks(4272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 787, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 471, DateTimeKind.Local).AddTicks(7405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(5309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 473, DateTimeKind.Local).AddTicks(6376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 796, DateTimeKind.Local).AddTicks(4240));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 473, DateTimeKind.Local).AddTicks(1686),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 796, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryItemImages",
                schema: "dbo",
                table: "CategoryItemImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_CategoryItemImages_CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems",
                column: "CategoryItemImageId",
                principalSchema: "dbo",
                principalTable: "CategoryItemImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_CategoryItemImages_CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryItemImages",
                schema: "dbo",
                table: "CategoryItemImages");

            migrationBuilder.RenameTable(
                name: "CategoryItemImages",
                schema: "dbo",
                newName: "CatalogItemImages",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(9772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 472, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(8144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 472, DateTimeKind.Local).AddTicks(4553));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 787, DateTimeKind.Local).AddTicks(7937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 459, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 795, DateTimeKind.Local).AddTicks(5309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 471, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 796, DateTimeKind.Local).AddTicks(4240),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 473, DateTimeKind.Local).AddTicks(6376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 28, 0, 12, 19, 796, DateTimeKind.Local).AddTicks(1946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 473, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogItemImages",
                schema: "dbo",
                table: "CatalogItemImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_CatalogItemImages_CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems",
                column: "CategoryItemImageId",
                principalSchema: "dbo",
                principalTable: "CatalogItemImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
