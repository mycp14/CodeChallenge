using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class rename_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Pizzas_PizzaId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaTypes_PizzaTypeId",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PizzaTypes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Ingredients",
                table: "PizzaTypes",
                newName: "ingredients");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "PizzaTypes",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "PizzaTypeId",
                table: "PizzaTypes",
                newName: "pizza_type_id");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Pizzas",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Pizzas",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "PizzaTypeId",
                table: "Pizzas",
                newName: "pizza_type_id");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "Pizzas",
                newName: "pizza_id");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_PizzaTypeId",
                table: "Pizzas",
                newName: "IX_Pizzas_pizza_type_id");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Orders",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Orders",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetails",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "OrderDetails",
                newName: "pizza_id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetails",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "OrderDetails",
                newName: "order_detail_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_PizzaId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_pizza_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_order_id",
                table: "OrderDetails",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Pizzas_pizza_id",
                table: "OrderDetails",
                column: "pizza_id",
                principalTable: "Pizzas",
                principalColumn: "pizza_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaTypes_pizza_type_id",
                table: "Pizzas",
                column: "pizza_type_id",
                principalTable: "PizzaTypes",
                principalColumn: "pizza_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_order_id",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Pizzas_pizza_id",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaTypes_pizza_type_id",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "PizzaTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ingredients",
                table: "PizzaTypes",
                newName: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "PizzaTypes",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "pizza_type_id",
                table: "PizzaTypes",
                newName: "PizzaTypeId");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "Pizzas",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Pizzas",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "pizza_type_id",
                table: "Pizzas",
                newName: "PizzaTypeId");

            migrationBuilder.RenameColumn(
                name: "pizza_id",
                table: "Pizzas",
                newName: "PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_pizza_type_id",
                table: "Pizzas",
                newName: "IX_Pizzas_PizzaTypeId");

            migrationBuilder.RenameColumn(
                name: "time",
                table: "Orders",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Orders",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "pizza_id",
                table: "OrderDetails",
                newName: "PizzaId");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "order_detail_id",
                table: "OrderDetails",
                newName: "OrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_pizza_id",
                table: "OrderDetails",
                newName: "IX_OrderDetails_PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_order_id",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Pizzas_PizzaId",
                table: "OrderDetails",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "PizzaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaTypes_PizzaTypeId",
                table: "Pizzas",
                column: "PizzaTypeId",
                principalTable: "PizzaTypes",
                principalColumn: "PizzaTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
