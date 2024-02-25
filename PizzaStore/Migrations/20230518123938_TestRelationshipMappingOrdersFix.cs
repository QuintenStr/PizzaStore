using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Migrations
{
    public partial class TestRelationshipMappingOrdersFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_DeliveryOrders_DeliveryOrderFK",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_PickupOrders_PickupOrderFK",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_DeliveryOrderFK",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_PickupOrderFK",
                table: "OrderLines");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryOrderOrderId",
                table: "OrderLines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PickupOrderOrderId",
                table: "OrderLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_DeliveryOrderOrderId",
                table: "OrderLines",
                column: "DeliveryOrderOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_PickupOrderOrderId",
                table: "OrderLines",
                column: "PickupOrderOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_DeliveryOrders_DeliveryOrderOrderId",
                table: "OrderLines",
                column: "DeliveryOrderOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_PickupOrders_PickupOrderOrderId",
                table: "OrderLines",
                column: "PickupOrderOrderId",
                principalTable: "PickupOrders",
                principalColumn: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_DeliveryOrders_DeliveryOrderOrderId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_PickupOrders_PickupOrderOrderId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_DeliveryOrderOrderId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_PickupOrderOrderId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "DeliveryOrderOrderId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "PickupOrderOrderId",
                table: "OrderLines");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_DeliveryOrderFK",
                table: "OrderLines",
                column: "DeliveryOrderFK");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_PickupOrderFK",
                table: "OrderLines",
                column: "PickupOrderFK");

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
    }
}
