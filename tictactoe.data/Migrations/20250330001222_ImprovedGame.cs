using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tictactoe.data.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Games",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerXId",
                table: "Games",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerOId",
                table: "Games",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "OutcomeReason",
                table: "Games",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OutcomeStatus",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinningLineLength",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutcomeReason",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OutcomeStatus",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "WinningLineLength",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Games",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerXId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerOId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Games",
                type: "integer",
                nullable: true);
        }
    }
}
