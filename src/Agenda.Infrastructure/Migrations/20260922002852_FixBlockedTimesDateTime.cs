using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixBlockedTimesDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "start_datetime",
                table: "blocked_times");

            migrationBuilder.DropColumn(
                name: "end_datetime",
                table: "blocked_times");

            migrationBuilder.AddColumn<DateTime>(
                name: "start_datetime",
                table: "blocked_times",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTime.UnixEpoch);

            migrationBuilder.AddColumn<DateTime>(
                name: "end_datetime",
                table: "blocked_times",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: DateTime.UnixEpoch);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "start_datetime",
                table: "blocked_times");

            migrationBuilder.DropColumn(
                name: "end_datetime",
                table: "blocked_times");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "start_datetime",
                table: "blocked_times",
                type: "interval",
                nullable: false,
                defaultValue: TimeSpan.Zero);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "end_datetime",
                table: "blocked_times",
                type: "interval",
                nullable: false,
                defaultValue: TimeSpan.Zero);
        }
    }
}