using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleSystem.Database.Migrations
{
    /// <inheritdoc />
    public partial class GenderColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "PersonalInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "PersonalInformations");
        }
    }
}
