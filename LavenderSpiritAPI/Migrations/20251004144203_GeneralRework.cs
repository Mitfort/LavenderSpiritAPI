using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavenderSpiritAPI.Migrations
{
    /// <inheritdoc />
    public partial class GeneralRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AdditionalInformations",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "OrganizatorID",
                table: "Events",
                newName: "OwnerID");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerVoluntreeID",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Voluntrees",
                columns: table => new
                {
                    VoluntreeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntrees", x => x.VoluntreeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_OwnerVoluntreeID",
                table: "Events",
                column: "OwnerVoluntreeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Voluntrees_OwnerVoluntreeID",
                table: "Events",
                column: "OwnerVoluntreeID",
                principalTable: "Voluntrees",
                principalColumn: "VoluntreeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Voluntrees_OwnerVoluntreeID",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Voluntrees");

            migrationBuilder.DropIndex(
                name: "IX_Events_OwnerVoluntreeID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OwnerVoluntreeID",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Events",
                newName: "OrganizatorID");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformations",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventID",
                table: "Events",
                column: "EventID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID",
                table: "Users",
                column: "UserID",
                unique: true);
        }
    }
}
