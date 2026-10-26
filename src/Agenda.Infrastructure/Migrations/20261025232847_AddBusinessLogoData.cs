using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessLogoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logo_url",
                table: "business");

            migrationBuilder.AddColumn<string>(
                name: "logo_content_type",
                table: "business",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "logo_data",
                table: "business",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logo_content_type",
                table: "business");

            migrationBuilder.DropColumn(
                name: "logo_data",
                table: "business");

            migrationBuilder.AddColumn<string>(
                name: "logo_url",
                table: "business",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
