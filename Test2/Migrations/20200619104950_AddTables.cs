using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedType",
                columns: table => new
                {
                    IdBreedType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedType", x => x.IdBreedType);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    IdVoluenteer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSupervisor = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.IdVoluenteer);
                    table.ForeignKey(
                        name: "FK_Volunteer_Volunteer_IdSupervisor",
                        column: x => x.IdSupervisor,
                        principalTable: "Volunteer",
                        principalColumn: "IdVoluenteer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    IdPet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBreedType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IsMale = table.Column<bool>(nullable: false),
                    DateRegistred = table.Column<DateTime>(nullable: false),
                    ApprocimateDateOfBirth = table.Column<DateTime>(nullable: false),
                    DateAdopted = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.IdPet);
                    table.ForeignKey(
                        name: "FK_Pet_BreedType_IdBreedType",
                        column: x => x.IdBreedType,
                        principalTable: "BreedType",
                        principalColumn: "IdBreedType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer_Pet",
                columns: table => new
                {
                    IdVolunteer = table.Column<int>(nullable: false),
                    IdPet = table.Column<int>(nullable: false),
                    DateAccepted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer_Pet", x => new { x.IdVolunteer, x.IdPet });
                    table.ForeignKey(
                        name: "FK_Volunteer_Pet_Pet_IdPet",
                        column: x => x.IdPet,
                        principalTable: "Pet",
                        principalColumn: "IdPet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Volunteer_Pet_Volunteer_IdVolunteer",
                        column: x => x.IdVolunteer,
                        principalTable: "Volunteer",
                        principalColumn: "IdVoluenteer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdBreedType",
                table: "Pet",
                column: "IdBreedType");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_IdSupervisor",
                table: "Volunteer",
                column: "IdSupervisor");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_Pet_IdPet",
                table: "Volunteer_Pet",
                column: "IdPet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteer_Pet");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "BreedType");
        }
    }
}
