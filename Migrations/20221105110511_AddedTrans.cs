using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace homework_64_Atai.Migrations
{
    public partial class AddedTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transjs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    amountOfTrans = table.Column<int>(nullable: false),
                    WhoSendId = table.Column<int>(nullable: false),
                    WhoGetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transjs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transjs_AspNetUsers_WhoGetId",
                        column: x => x.WhoGetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transjs_AspNetUsers_WhoSendId",
                        column: x => x.WhoSendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transjs_WhoGetId",
                table: "Transjs",
                column: "WhoGetId");

            migrationBuilder.CreateIndex(
                name: "IX_Transjs_WhoSendId",
                table: "Transjs",
                column: "WhoSendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transjs");
        }
    }
}
