using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleSystem.Database.Migrations
{
    /// <inheritdoc />
    public partial class UserToManyPersonsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInformations_UserId",
                table: "PersonalInformations");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_UserId",
                table: "PersonalInformations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInformations_UserId",
                table: "PersonalInformations");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_UserId",
                table: "PersonalInformations",
                column: "UserId",
                unique: true);
        }
    }
}
