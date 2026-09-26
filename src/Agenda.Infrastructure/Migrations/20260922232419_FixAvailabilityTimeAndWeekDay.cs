using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixAvailabilityTimeAndWeekDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "week_day",
                table: "availability",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.DropColumn(
                name: "start_time",
                table: "availability");

            migrationBuilder.DropColumn(
                name: "end_time",
                table: "availability");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "start_time",
                table: "availability",
                type: "interval",
                nullable: false,
                defaultValue: TimeSpan.Zero);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "end_time",
                table: "availability",
                type: "interval",
                nullable: false,
                defaultValue: TimeSpan.Zero);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "start_time",
                table: "availability");

            migrationBuilder.DropColumn(
                name: "end_time",
                table: "availability");

            migrationBuilder.AddColumn<DateTime>(
                name: "start_time",
                table: "availability",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTime.UnixEpoch);

            migrationBuilder.AddColumn<DateTime>(
                name: "end_time",
                table: "availability",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTime.UnixEpoch);

            migrationBuilder.AlterColumn<int>(
                name: "week_day",
                table: "availability",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }
    }
}