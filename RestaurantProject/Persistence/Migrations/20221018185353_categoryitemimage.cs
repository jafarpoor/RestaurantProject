using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class categoryitemimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItemImages_CategoryItems_CatalogItemId",
                schema: "dbo",
                table: "CatalogItemImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_Categories_ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.DropIndex(
                name: "IX_CatalogItemImages_CatalogItemId",
                schema: "dbo",
                table: "CatalogItemImages");

            migrationBuilder.DropColumn(
                name: "CatalogItemId",
                schema: "dbo",
                table: "CatalogItemImages");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "CategoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(3965),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 21, 53, 55, 324, DateTimeKind.Local).AddTicks(5311));

            migrationBuilder.AddColumn<int>(
                name: "CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 354, DateTimeKind.Local).AddTicks(2397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 21, 53, 55, 324, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(6885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 21, 53, 55, 313, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(9136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 21, 53, 55, 325, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems",
                column: "CategoryItemImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_CatalogItemImages_CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems",
                column: "CategoryItemImageId",
                principalSchema: "dbo",
                principalTable: "CatalogItemImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_Categories_ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems",
                column: "ParentCategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_CatalogItemImages_CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_Categories_ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItems_CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.DropColumn(
                name: "CategoryItemImageId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "CategoryItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 21, 53, 55, 324, DateTimeKind.Local).AddTicks(5311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 21, 53, 55, 324, DateTimeKind.Local).AddTicks(2490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 354, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 21, 53, 55, 313, DateTimeKind.Local).AddTicks(8321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.AddColumn<int>(
                name: "CatalogItemId",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 21, 53, 55, 325, DateTimeKind.Local).AddTicks(486),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemImages_CatalogItemId",
                schema: "dbo",
                table: "CatalogItemImages",
                column: "CatalogItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItemImages_CategoryItems_CatalogItemId",
                schema: "dbo",
                table: "CatalogItemImages",
                column: "CatalogItemId",
                principalSchema: "dbo",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_Categories_ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems",
                column: "ParentCategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
