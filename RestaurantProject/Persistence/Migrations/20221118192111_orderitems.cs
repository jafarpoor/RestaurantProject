using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class orderitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 432, DateTimeKind.Local).AddTicks(3700),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 431, DateTimeKind.Local).AddTicks(9980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 432, DateTimeKind.Local).AddTicks(1761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(5392));

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
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
                defaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 431, DateTimeKind.Local).AddTicks(6241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 431, DateTimeKind.Local).AddTicks(8286),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 431, DateTimeKind.Local).AddTicks(4578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 414, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 422, DateTimeKind.Local).AddTicks(9102),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 406, DateTimeKind.Local).AddTicks(4862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 430, DateTimeKind.Local).AddTicks(9428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 414, DateTimeKind.Local).AddTicks(5489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 432, DateTimeKind.Local).AddTicks(5953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "dbo",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "dbo",
                table: "OrderItems",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "dbo",
                table: "OrderItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(6915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 432, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(3859),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 431, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(5392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 432, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(104),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 431, DateTimeKind.Local).AddTicks(6241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "CategoryItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(2182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 431, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 414, DateTimeKind.Local).AddTicks(8392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 431, DateTimeKind.Local).AddTicks(4578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 406, DateTimeKind.Local).AddTicks(4862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 422, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 414, DateTimeKind.Local).AddTicks(5489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 430, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 22, 11, 53, 415, DateTimeKind.Local).AddTicks(9523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 22, 51, 10, 432, DateTimeKind.Local).AddTicks(5953));
        }
    }
}
