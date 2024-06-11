using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleSystem.Database.Migrations
{
    /// <inheritdoc />
    public partial class SmallCorrectionOnFieldSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePhotoPath",
                table: "ProfilePhotos",
                newName: "PhotoPath");

            migrationBuilder.AlterColumn<string>(
                name: "ApartmentNumber",
                table: "PlacesOfResidence",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "ProfilePhotos",
                newName: "ProfilePhotoPath");

            migrationBuilder.AlterColumn<string>(
                name: "ApartmentNumber",
                table: "PlacesOfResidence",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
