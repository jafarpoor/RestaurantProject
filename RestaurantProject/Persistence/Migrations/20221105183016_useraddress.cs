using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class useraddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 120, DateTimeKind.Local).AddTicks(9622),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 472, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 121, DateTimeKind.Local).AddTicks(5179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 473, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 120, DateTimeKind.Local).AddTicks(5180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 472, DateTimeKind.Local).AddTicks(4553));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 94, DateTimeKind.Local).AddTicks(1872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 459, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 119, DateTimeKind.Local).AddTicks(7616),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 471, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 122, DateTimeKind.Local).AddTicks(1240),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 473, DateTimeKind.Local).AddTicks(6376));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 472, DateTimeKind.Local).AddTicks(7519),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 120, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 473, DateTimeKind.Local).AddTicks(1686),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 121, DateTimeKind.Local).AddTicks(5179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 472, DateTimeKind.Local).AddTicks(4553),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 120, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 459, DateTimeKind.Local).AddTicks(4272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 94, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 471, DateTimeKind.Local).AddTicks(7405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 119, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 18, 27, 4, 473, DateTimeKind.Local).AddTicks(6376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 5, 22, 0, 15, 122, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
