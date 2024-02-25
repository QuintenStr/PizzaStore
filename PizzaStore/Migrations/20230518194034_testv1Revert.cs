using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Migrations
{
    public partial class testv1Revert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtratoppingsOrderLines");

            migrationBuilder.CreateTable(
                name: "ExtratoppingsOrderLine",
                columns: table => new
                {
                    ExtraToppingsIngredientId = table.Column<int>(type: "int", nullable: false),
                    OrderLinesOrderLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtratoppingsOrderLine", x => new { x.ExtraToppingsIngredientId, x.OrderLinesOrderLineId });
                    table.ForeignKey(
                        name: "FK_ExtratoppingsOrderLine_Ingredients_ExtraToppingsIngredientId",
                        column: x => x.ExtraToppingsIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtratoppingsOrderLine_OrderLines_OrderLinesOrderLineId",
                        column: x => x.OrderLinesOrderLineId,
                        principalTable: "OrderLines",
                        principalColumn: "OrderLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtratoppingsOrderLine_OrderLinesOrderLineId",
                table: "ExtratoppingsOrderLine",
                column: "OrderLinesOrderLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtratoppingsOrderLine");

            migrationBuilder.CreateTable(
                name: "ExtratoppingsOrderLines",
                columns: table => new
                {
                    ExtratoppingsOrderLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraToppingsIngredientId = table.Column<int>(type: "int", nullable: false),
                    OrderLinesOrderLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtratoppingsOrderLines", x => x.ExtratoppingsOrderLineId);
                    table.ForeignKey(
                        name: "FK_ExtratoppingsOrderLines_Ingredients_ExtraToppingsIngredientId",
                        column: x => x.ExtraToppingsIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtratoppingsOrderLines_OrderLines_OrderLinesOrderLineId",
                        column: x => x.OrderLinesOrderLineId,
                        principalTable: "OrderLines",
                        principalColumn: "OrderLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtratoppingsOrderLines_ExtraToppingsIngredientId",
                table: "ExtratoppingsOrderLines",
                column: "ExtraToppingsIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtratoppingsOrderLines_OrderLinesOrderLineId",
                table: "ExtratoppingsOrderLines",
                column: "OrderLinesOrderLineId");
        }
    }
}
