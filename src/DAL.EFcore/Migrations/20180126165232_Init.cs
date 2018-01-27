using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.EFcore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EfRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EfRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EfStations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EfRouteId = table.Column<int>(nullable: false),
                    NameCh = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EfStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EfStations_EfRoutes_EfRouteId",
                        column: x => x.EfRouteId,
                        principalTable: "EfRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EfStations_EfRouteId",
                table: "EfStations",
                column: "EfRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EfStations");

            migrationBuilder.DropTable(
                name: "EfRoutes");
        }
    }
}
