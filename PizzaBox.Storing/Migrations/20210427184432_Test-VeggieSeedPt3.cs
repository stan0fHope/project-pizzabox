using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class TestVeggieSeedPt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "APizzaEntityId1",
                table: "Toppings",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "EntityId", "CrustEntityId", "Discriminator", "OrderEntityId", "SizeEntityId" },
                values: new object[] { 1L, 1L, "VeggiePizza", null, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_APizzaEntityId1",
                table: "Toppings",
                column: "APizzaEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityId1",
                table: "Toppings",
                column: "APizzaEntityId1",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityId1",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_APizzaEntityId1",
                table: "Toppings");

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "APizzaEntityId1",
                table: "Toppings");
        }
    }
}
