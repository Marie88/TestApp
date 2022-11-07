using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.Module.Rfc.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "rfc");

            migrationBuilder.CreateTable(
                name: "RequestForChange",
                schema: "rfc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    DateRaised = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestForChange", x => x.Id);
                    table.UniqueConstraint("AK_RequestForChange_Key", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestForChange",
                schema: "rfc");
        }
    }
}
