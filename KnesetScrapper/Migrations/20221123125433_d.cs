using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnesetScrapper.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SessionsRetrieved",
                table: "Speakers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionsRetrieved",
                table: "Speakers");
        }
    }
}
