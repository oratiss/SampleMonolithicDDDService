using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SystemDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

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
                    CustomesCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "IsDeleted", "SystemDescription", "Title" },
                values: new object[] { 1L, "A role for system administrators", false, "System.UserManagement.Roles.Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "IsDeleted", "SystemDescription", "Title" },
                values: new object[] { 2L, "A role for registered users", false, "System.UserManagement.Roles.RegisteredUser", "RegisteredUser" });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_RoleId",
                table: "Positions",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionActivities");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
