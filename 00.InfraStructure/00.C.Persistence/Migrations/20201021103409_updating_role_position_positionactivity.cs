using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updating_role_position_positionactivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    DamageType = table.Column<int>(nullable: false),
                    ErgonomicStatus = table.Column<int>(nullable: false),
                    PositionActivity_Viewing = table.Column<bool>(nullable: true),
                    PositionActivity_Hearing = table.Column<bool>(nullable: true),
                    PositionActivity_Thinking = table.Column<bool>(nullable: true),
                    PositionActivity_Tasting = table.Column<bool>(nullable: true),
                    PositionActivity_Smelling = table.Column<bool>(nullable: true),
                    PositionActivity_Other = table.Column<string>(nullable: true),
                    CustomesCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "IsDeleted", "SystemDescription", "Title" },
                values: new object[] { 1, "A role for system administrators", false, "System.UserManagement.Roles.Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_RoleId",
                table: "Positions",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");
        }
    }
}
