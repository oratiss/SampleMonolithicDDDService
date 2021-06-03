using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class changesmadetouseraccounting22102020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionActivity_Hearing",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "PositionActivity_Other",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "PositionActivity_Smelling",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "PositionActivity_Tasting",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "PositionActivity_Thinking",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "PositionActivity_Viewing",
                table: "Positions");

            migrationBuilder.CreateTable(
                name: "PositionActivities",
                columns: table => new
                {
                    PositionId = table.Column<int>(nullable: false),
                    Viewing = table.Column<bool>(nullable: false),
                    Hearing = table.Column<bool>(nullable: false),
                    Thinking = table.Column<bool>(nullable: false),
                    Tasting = table.Column<bool>(nullable: false),
                    Smelling = table.Column<bool>(nullable: false),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionActivities", x => x.PositionId);
                    table.ForeignKey(
                        name: "FK_PositionActivities_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionActivities");

            migrationBuilder.AddColumn<bool>(
                name: "PositionActivity_Hearing",
                table: "Positions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionActivity_Other",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PositionActivity_Smelling",
                table: "Positions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PositionActivity_Tasting",
                table: "Positions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PositionActivity_Thinking",
                table: "Positions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PositionActivity_Viewing",
                table: "Positions",
                type: "bit",
                nullable: true);
        }
    }
}
