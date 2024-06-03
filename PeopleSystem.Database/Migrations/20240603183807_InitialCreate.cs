using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleSystem.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PersonalIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInformations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlacesOfResidence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesOfResidence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacesOfResidence_PersonalInformations_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilePhotos_PersonalInformations_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_UserId",
                table: "PersonalInformations",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlacesOfResidence_PersonalInformationId",
                table: "PlacesOfResidence",
                column: "PersonalInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePhotos_PersonalInformationId",
                table: "ProfilePhotos",
                column: "PersonalInformationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacesOfResidence");

            migrationBuilder.DropTable(
                name: "ProfilePhotos");

            migrationBuilder.DropTable(
                name: "PersonalInformations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
