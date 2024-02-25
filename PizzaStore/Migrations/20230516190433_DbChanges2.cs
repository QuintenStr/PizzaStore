using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Migrations
{
    public partial class DbChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_DeliveryOrders_DeliveryOrderFK",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_PickupOrders_PickupOrderFK",
                table: "OrderLines");

            migrationBuilder.AlterColumn<int>(
                name: "PickupOrderFK",
                table: "OrderLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryOrderFK",
                table: "OrderLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_DeliveryOrders_DeliveryOrderFK",
                table: "OrderLines",
                column: "DeliveryOrderFK",
                principalTable: "DeliveryOrders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_PickupOrders_PickupOrderFK",
                table: "OrderLines",
                column: "PickupOrderFK",
                principalTable: "PickupOrders",
                principalColumn: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_DeliveryOrders_DeliveryOrderFK",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_PickupOrders_PickupOrderFK",
                table: "OrderLines");

            migrationBuilder.AlterColumn<int>(
                name: "PickupOrderFK",
                table: "OrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryOrderFK",
                table: "OrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_DeliveryOrders_DeliveryOrderFK",
                table: "OrderLines",
                column: "DeliveryOrderFK",
                principalTable: "DeliveryOrders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_PickupOrders_PickupOrderFK",
                table: "OrderLines",
                column: "PickupOrderFK",
                principalTable: "PickupOrders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
