using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameIdColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "services",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "service_staff",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "business_settings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "business",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "blocked_times",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "availability",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "appointments",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "services",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "service_staff",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "business_settings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "business",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "blocked_times",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "availability",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "appointments",
                newName: "Id");
        }
    }
}
