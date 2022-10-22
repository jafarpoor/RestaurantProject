using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class catergoryparent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_Categories_ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItems_ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                schema: "dbo",
                table: "CategoryItems",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 871, DateTimeKind.Local).AddTicks(5602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 861, DateTimeKind.Local).AddTicks(8959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 354, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 871, DateTimeKind.Local).AddTicks(9851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 872, DateTimeKind.Local).AddTicks(4067),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_CategoryId",
                schema: "dbo",
                table: "CategoryItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_Categories_CategoryId",
                schema: "dbo",
                table: "CategoryItems",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_Categories_CategoryId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItems_CategoryId",
                schema: "dbo",
                table: "CategoryItems");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "CategoryItems",
                newName: "ParentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(3965),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 871, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
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
                oldDefaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 861, DateTimeKind.Local).AddTicks(8959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(6885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 871, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 22, 23, 53, 363, DateTimeKind.Local).AddTicks(9136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 872, DateTimeKind.Local).AddTicks(4067));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_ParentCategoryId",
                schema: "dbo",
                table: "CategoryItems",
                column: "ParentCategoryId");

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
    }
}
