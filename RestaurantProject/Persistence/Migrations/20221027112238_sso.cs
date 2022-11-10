using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class sso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 270, DateTimeKind.Local).AddTicks(9383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 871, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercentage",
                schema: "dbo",
                table: "CategoryItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 218, DateTimeKind.Local).AddTicks(804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 861, DateTimeKind.Local).AddTicks(8959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 271, DateTimeKind.Local).AddTicks(3568),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 871, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 271, DateTimeKind.Local).AddTicks(6992),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 872, DateTimeKind.Local).AddTicks(4067));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 871, DateTimeKind.Local).AddTicks(5602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 270, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercentage",
                schema: "dbo",
                table: "CategoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 861, DateTimeKind.Local).AddTicks(8959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 218, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CatalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 871, DateTimeKind.Local).AddTicks(9851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 271, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 21, 23, 18, 20, 872, DateTimeKind.Local).AddTicks(4067),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 27, 14, 52, 38, 271, DateTimeKind.Local).AddTicks(6992));
        }
    }
}
