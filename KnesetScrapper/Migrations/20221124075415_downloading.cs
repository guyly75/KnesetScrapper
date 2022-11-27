using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnesetScrapper.Migrations
{
    /// <inheritdoc />
    public partial class downloading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Downloaded",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Downloaded",
                table: "Sessions");
        }
    }
}
