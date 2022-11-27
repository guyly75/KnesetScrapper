using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnesetScrapper.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionMovieURL",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SessionSpeaker",
                columns: table => new
                {
                    SessionsSessionId = table.Column<int>(type: "int", nullable: false),
                    SpeakersSpeakerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSpeaker", x => new { x.SessionsSessionId, x.SpeakersSpeakerId });
                    table.ForeignKey(
                        name: "FK_SessionSpeaker_Sessions_SessionsSessionId",
                        column: x => x.SessionsSessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSpeaker_Speakers_SpeakersSpeakerId",
                        column: x => x.SpeakersSpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "SpeakerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionSpeaker_SpeakersSpeakerId",
                table: "SessionSpeaker",
                column: "SpeakersSpeakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionSpeaker");

            migrationBuilder.DropColumn(
                name: "SessionMovieURL",
                table: "Sessions");
        }
    }
}
