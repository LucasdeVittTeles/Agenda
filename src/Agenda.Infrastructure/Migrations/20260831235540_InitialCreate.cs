using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "business",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Document = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Whatsapp = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Logo_Url = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Zip_Code = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Street = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    State = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Country = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Subscription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "business_settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Business_Id = table.Column<int>(type: "integer", nullable: false),
                    Allow_Online_Booking = table.Column<bool>(type: "boolean", nullable: false),
                    Appointment_Approval_Required = table.Column<bool>(type: "boolean", nullable: false),
                    Max_Daily_Appointments = table.Column<int>(type: "integer", nullable: false),
                    Cancelation_Limit_Hours = table.Column<int>(type: "integer", nullable: false),
                    Appointment_Interval_Minutes = table.Column<int>(type: "integer", nullable: false),
                    Working_Days = table.Column<List<string>>(type: "jsonb", nullable: false),
                    Theme_Color = table.Column<string>(type: "text", nullable: true),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business_settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_business_settings_business_Business_Id",
                        column: x => x.Business_Id,
                        principalTable: "business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Business_Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Default_Duration_Minutes = table.Column<int>(type: "integer", nullable: false),
                    Is_Active = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_services_business_Business_Id",
                        column: x => x.Business_Id,
                        principalTable: "business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    StaffType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AvatarUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "availability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_Id = table.Column<int>(type: "integer", nullable: false),
                    Week_Day = table.Column<int>(type: "integer", nullable: false),
                    Start_Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End_Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Is_Active = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_availability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_availability_users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blocked_times",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_Id = table.Column<int>(type: "integer", nullable: false),
                    Start_Datetime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    End_Datetime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Reason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blocked_times", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blocked_times_users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "service_staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Service_Id = table.Column<int>(type: "integer", nullable: false),
                    Staff_User_Id = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Duration_Minutes = table.Column<int>(type: "integer", nullable: true),
                    Is_Active = table.Column<bool>(type: "boolean", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_service_staff_services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_service_staff_users_Staff_User_Id",
                        column: x => x.Staff_User_Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Business_Id = table.Column<int>(type: "integer", nullable: false),
                    Client_User_Id = table.Column<int>(type: "integer", nullable: false),
                    Service_Staff_Id = table.Column<int>(type: "integer", nullable: false),
                    Start_Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End_Datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointments_business_Business_Id",
                        column: x => x.Business_Id,
                        principalTable: "business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_service_staff_Service_Staff_Id",
                        column: x => x.Service_Staff_Id,
                        principalTable: "service_staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_users_Client_User_Id",
                        column: x => x.Client_User_Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_Business_Id",
                table: "appointments",
                column: "Business_Id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_Client_User_Id",
                table: "appointments",
                column: "Client_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_Service_Staff_Id",
                table: "appointments",
                column: "Service_Staff_Id");

            migrationBuilder.CreateIndex(
                name: "IX_availability_User_Id",
                table: "availability",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_blocked_times_User_Id",
                table: "blocked_times",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_business_settings_Business_Id",
                table: "business_settings",
                column: "Business_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_service_staff_Service_Id_Staff_User_Id",
                table: "service_staff",
                columns: new[] { "Service_Id", "Staff_User_Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_service_staff_Staff_User_Id",
                table: "service_staff",
                column: "Staff_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_services_Business_Id",
                table: "services",
                column: "Business_Id");

            migrationBuilder.CreateIndex(
                name: "IX_users_BusinessId",
                table: "users",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_users_email_unique",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "availability");

            migrationBuilder.DropTable(
                name: "blocked_times");

            migrationBuilder.DropTable(
                name: "business_settings");

            migrationBuilder.DropTable(
                name: "service_staff");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "business");
        }
    }
}
