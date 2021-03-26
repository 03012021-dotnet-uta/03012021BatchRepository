using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
	public partial class migration3 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_LikesJunction",
				table: "LikesJunction");

			migrationBuilder.DropColumn(
				name: "LikesJunctionId",
				table: "LikesJunction");

			migrationBuilder.AddPrimaryKey(
				name: "PK_LikesJunction",
				table: "LikesJunction",
				columns: new[] { "PersonId", "MemeId" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_LikesJunction",
				table: "LikesJunction");

			migrationBuilder.AddColumn<int>(
				name: "LikesJunctionId",
				table: "LikesJunction",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddPrimaryKey(
				name: "PK_LikesJunction",
				table: "LikesJunction",
				column: "LikesJunctionId");
		}
	}
}
