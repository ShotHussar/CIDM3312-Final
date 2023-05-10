using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_ShotHussar.Migrations
{
    public partial class SecondCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtBat",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "BattingAvg",
                table: "Players",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "MLBTeam",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RBI",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Runs",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StrikeOuts",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtBat",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "BattingAvg",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MLBTeam",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RBI",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Runs",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "StrikeOuts",
                table: "Players");
        }
    }
}
