using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class useraddresss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(9836),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(5824));

            migrationBuilder.AlterColumn<long>(
                name: "UnitPrice",
                schema: "dbo",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 317, DateTimeKind.Local).AddTicks(1072),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(6710),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 29, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(8582),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(5005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 29, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 308, DateTimeKind.Local).AddTicks(4503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 21, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(1916),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 28, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 317, DateTimeKind.Local).AddTicks(3760),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReciverName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddresses",
                schema: "dbo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(5824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.AlterColumn<int>(
                name: "UnitPrice",
                schema: "dbo",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(7470),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 317, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 29, DateTimeKind.Local).AddTicks(3973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(2846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(8582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 29, DateTimeKind.Local).AddTicks(2380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(5005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 21, DateTimeKind.Local).AddTicks(7344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 308, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 28, DateTimeKind.Local).AddTicks(9841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 316, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 22, 16, 4, 30, DateTimeKind.Local).AddTicks(9630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 14, 6, 37, 41, 317, DateTimeKind.Local).AddTicks(3760));
        }
    }
}
