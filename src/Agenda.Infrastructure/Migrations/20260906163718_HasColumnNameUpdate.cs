using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HasColumnNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_business_Business_Id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_service_staff_Service_Staff_Id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_users_Client_User_Id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_availability_users_User_Id",
                table: "availability");

            migrationBuilder.DropForeignKey(
                name: "FK_blocked_times_users_User_Id",
                table: "blocked_times");

            migrationBuilder.DropForeignKey(
                name: "FK_business_settings_business_Business_Id",
                table: "business_settings");

            migrationBuilder.DropForeignKey(
                name: "FK_service_staff_services_Service_Id",
                table: "service_staff");

            migrationBuilder.DropForeignKey(
                name: "FK_service_staff_users_Staff_User_Id",
                table: "service_staff");

            migrationBuilder.DropForeignKey(
                name: "FK_services_business_Business_Id",
                table: "services");

            migrationBuilder.DropForeignKey(
                name: "FK_users_business_BusinessId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "users",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "users",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "StaffType",
                table: "users",
                newName: "staff_type");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "users",
                newName: "business_id");

            migrationBuilder.RenameColumn(
                name: "AvatarUrl",
                table: "users",
                newName: "avatar_url");

            migrationBuilder.RenameIndex(
                name: "IX_users_BusinessId",
                table: "users",
                newName: "IX_users_business_id");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "services",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "services",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Is_Active",
                table: "services",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "services",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Default_Duration_Minutes",
                table: "services",
                newName: "default_duration_minutes");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "services",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Business_Id",
                table: "services",
                newName: "business_id");

            migrationBuilder.RenameIndex(
                name: "IX_services_Business_Id",
                table: "services",
                newName: "IX_services_business_id");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "service_staff",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Staff_User_Id",
                table: "service_staff",
                newName: "staff_user_id");

            migrationBuilder.RenameColumn(
                name: "Service_Id",
                table: "service_staff",
                newName: "service_id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "service_staff",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Is_Active",
                table: "service_staff",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "Duration_Minutes",
                table: "service_staff",
                newName: "duration_minutes");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "service_staff",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_service_staff_Staff_User_Id",
                table: "service_staff",
                newName: "IX_service_staff_staff_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_service_staff_Service_Id_Staff_User_Id",
                table: "service_staff",
                newName: "IX_service_staff_service_id_staff_user_id");

            migrationBuilder.RenameColumn(
                name: "Working_Days",
                table: "business_settings",
                newName: "working_days");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "business_settings",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Theme_Color",
                table: "business_settings",
                newName: "theme_color");

            migrationBuilder.RenameColumn(
                name: "Max_Daily_Appointments",
                table: "business_settings",
                newName: "max_daily_appointments");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "business_settings",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Cancelation_Limit_Hours",
                table: "business_settings",
                newName: "cancelation_limit_hours");

            migrationBuilder.RenameColumn(
                name: "Business_Id",
                table: "business_settings",
                newName: "business_id");

            migrationBuilder.RenameColumn(
                name: "Appointment_Interval_Minutes",
                table: "business_settings",
                newName: "appointment_interval_minutes");

            migrationBuilder.RenameColumn(
                name: "Appointment_Approval_Required",
                table: "business_settings",
                newName: "appointment_approval_required");

            migrationBuilder.RenameColumn(
                name: "Allow_Online_Booking",
                table: "business_settings",
                newName: "allow_online_booking");

            migrationBuilder.RenameIndex(
                name: "IX_business_settings_Business_Id",
                table: "business_settings",
                newName: "IX_business_settings_business_id");

            migrationBuilder.RenameColumn(
                name: "Zip_Code",
                table: "business",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "Whatsapp",
                table: "business",
                newName: "whatsapp");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "business",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Subscription",
                table: "business",
                newName: "subscription");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "business",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "business",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "business",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "business",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "business",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Logo_Url",
                table: "business",
                newName: "logo_url");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "business",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Document",
                table: "business",
                newName: "document");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "business",
                newName: "district");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "business",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "business",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "business",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "blocked_times",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "blocked_times",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Start_Datetime",
                table: "blocked_times",
                newName: "start_datetime");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "blocked_times",
                newName: "reason");

            migrationBuilder.RenameColumn(
                name: "End_Datetime",
                table: "blocked_times",
                newName: "end_datetime");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "blocked_times",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_blocked_times_User_Id",
                table: "blocked_times",
                newName: "IX_blocked_times_user_id");

            migrationBuilder.RenameColumn(
                name: "Week_Day",
                table: "availability",
                newName: "week_day");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "availability",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "availability",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Start_Time",
                table: "availability",
                newName: "start_time");

            migrationBuilder.RenameColumn(
                name: "Is_Active",
                table: "availability",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "End_Time",
                table: "availability",
                newName: "end_time");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "availability",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_availability_User_Id",
                table: "availability",
                newName: "IX_availability_user_id");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "appointments",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "appointments",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Start_Datetime",
                table: "appointments",
                newName: "start_datetime");

            migrationBuilder.RenameColumn(
                name: "Service_Staff_Id",
                table: "appointments",
                newName: "service_staff_id");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "appointments",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "End_Datetime",
                table: "appointments",
                newName: "end_datetime");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "appointments",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Client_User_Id",
                table: "appointments",
                newName: "client_user_id");

            migrationBuilder.RenameColumn(
                name: "Business_Id",
                table: "appointments",
                newName: "business_id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_Service_Staff_Id",
                table: "appointments",
                newName: "IX_appointments_service_staff_id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_Client_User_Id",
                table: "appointments",
                newName: "IX_appointments_client_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_Business_Id",
                table: "appointments",
                newName: "IX_appointments_business_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_business_business_id",
                table: "appointments",
                column: "business_id",
                principalTable: "business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_service_staff_service_staff_id",
                table: "appointments",
                column: "service_staff_id",
                principalTable: "service_staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_client_user_id",
                table: "appointments",
                column: "client_user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_availability_users_user_id",
                table: "availability",
                column: "user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blocked_times_users_user_id",
                table: "blocked_times",
                column: "user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_business_settings_business_business_id",
                table: "business_settings",
                column: "business_id",
                principalTable: "business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_staff_services_service_id",
                table: "service_staff",
                column: "service_id",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_staff_users_staff_user_id",
                table: "service_staff",
                column: "staff_user_id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_services_business_business_id",
                table: "services",
                column: "business_id",
                principalTable: "business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_business_business_id",
                table: "users",
                column: "business_id",
                principalTable: "business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_business_business_id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_service_staff_service_staff_id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_users_client_user_id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_availability_users_user_id",
                table: "availability");

            migrationBuilder.DropForeignKey(
                name: "FK_blocked_times_users_user_id",
                table: "blocked_times");

            migrationBuilder.DropForeignKey(
                name: "FK_business_settings_business_business_id",
                table: "business_settings");

            migrationBuilder.DropForeignKey(
                name: "FK_service_staff_services_service_id",
                table: "service_staff");

            migrationBuilder.DropForeignKey(
                name: "FK_service_staff_users_staff_user_id",
                table: "service_staff");

            migrationBuilder.DropForeignKey(
                name: "FK_services_business_business_id",
                table: "services");

            migrationBuilder.DropForeignKey(
                name: "FK_users_business_business_id",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "users",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "users",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "staff_type",
                table: "users",
                newName: "StaffType");

            migrationBuilder.RenameColumn(
                name: "business_id",
                table: "users",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "avatar_url",
                table: "users",
                newName: "AvatarUrl");

            migrationBuilder.RenameIndex(
                name: "IX_users_business_id",
                table: "users",
                newName: "IX_users_BusinessId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "services",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "services",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "services",
                newName: "Is_Active");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "services",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "default_duration_minutes",
                table: "services",
                newName: "Default_Duration_Minutes");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "services",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "business_id",
                table: "services",
                newName: "Business_Id");

            migrationBuilder.RenameIndex(
                name: "IX_services_business_id",
                table: "services",
                newName: "IX_services_Business_Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "service_staff",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "staff_user_id",
                table: "service_staff",
                newName: "Staff_User_Id");

            migrationBuilder.RenameColumn(
                name: "service_id",
                table: "service_staff",
                newName: "Service_Id");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "service_staff",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "service_staff",
                newName: "Is_Active");

            migrationBuilder.RenameColumn(
                name: "duration_minutes",
                table: "service_staff",
                newName: "Duration_Minutes");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "service_staff",
                newName: "Created_At");

            migrationBuilder.RenameIndex(
                name: "IX_service_staff_staff_user_id",
                table: "service_staff",
                newName: "IX_service_staff_Staff_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_service_staff_service_id_staff_user_id",
                table: "service_staff",
                newName: "IX_service_staff_Service_Id_Staff_User_Id");

            migrationBuilder.RenameColumn(
                name: "working_days",
                table: "business_settings",
                newName: "Working_Days");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "business_settings",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "theme_color",
                table: "business_settings",
                newName: "Theme_Color");

            migrationBuilder.RenameColumn(
                name: "max_daily_appointments",
                table: "business_settings",
                newName: "Max_Daily_Appointments");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "business_settings",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "cancelation_limit_hours",
                table: "business_settings",
                newName: "Cancelation_Limit_Hours");

            migrationBuilder.RenameColumn(
                name: "business_id",
                table: "business_settings",
                newName: "Business_Id");

            migrationBuilder.RenameColumn(
                name: "appointment_interval_minutes",
                table: "business_settings",
                newName: "Appointment_Interval_Minutes");

            migrationBuilder.RenameColumn(
                name: "appointment_approval_required",
                table: "business_settings",
                newName: "Appointment_Approval_Required");

            migrationBuilder.RenameColumn(
                name: "allow_online_booking",
                table: "business_settings",
                newName: "Allow_Online_Booking");

            migrationBuilder.RenameIndex(
                name: "IX_business_settings_business_id",
                table: "business_settings",
                newName: "IX_business_settings_Business_Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "business",
                newName: "Zip_Code");

            migrationBuilder.RenameColumn(
                name: "whatsapp",
                table: "business",
                newName: "Whatsapp");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "business",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "subscription",
                table: "business",
                newName: "Subscription");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "business",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "business",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "business",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "business",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "business",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "logo_url",
                table: "business",
                newName: "Logo_Url");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "business",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "document",
                table: "business",
                newName: "Document");

            migrationBuilder.RenameColumn(
                name: "district",
                table: "business",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "business",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "business",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "business",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "blocked_times",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "blocked_times",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "start_datetime",
                table: "blocked_times",
                newName: "Start_Datetime");

            migrationBuilder.RenameColumn(
                name: "reason",
                table: "blocked_times",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "end_datetime",
                table: "blocked_times",
                newName: "End_Datetime");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "blocked_times",
                newName: "Created_At");

            migrationBuilder.RenameIndex(
                name: "IX_blocked_times_user_id",
                table: "blocked_times",
                newName: "IX_blocked_times_User_Id");

            migrationBuilder.RenameColumn(
                name: "week_day",
                table: "availability",
                newName: "Week_Day");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "availability",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "availability",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "start_time",
                table: "availability",
                newName: "Start_Time");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "availability",
                newName: "Is_Active");

            migrationBuilder.RenameColumn(
                name: "end_time",
                table: "availability",
                newName: "End_Time");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "availability",
                newName: "Created_At");

            migrationBuilder.RenameIndex(
                name: "IX_availability_user_id",
                table: "availability",
                newName: "IX_availability_User_Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "appointments",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "appointments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "start_datetime",
                table: "appointments",
                newName: "Start_Datetime");

            migrationBuilder.RenameColumn(
                name: "service_staff_id",
                table: "appointments",
                newName: "Service_Staff_Id");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "appointments",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "end_datetime",
                table: "appointments",
                newName: "End_Datetime");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "appointments",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "client_user_id",
                table: "appointments",
                newName: "Client_User_Id");

            migrationBuilder.RenameColumn(
                name: "business_id",
                table: "appointments",
                newName: "Business_Id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_service_staff_id",
                table: "appointments",
                newName: "IX_appointments_Service_Staff_Id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_client_user_id",
                table: "appointments",
                newName: "IX_appointments_Client_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_business_id",
                table: "appointments",
                newName: "IX_appointments_Business_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_business_Business_Id",
                table: "appointments",
                column: "Business_Id",
                principalTable: "business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_service_staff_Service_Staff_Id",
                table: "appointments",
                column: "Service_Staff_Id",
                principalTable: "service_staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_Client_User_Id",
                table: "appointments",
                column: "Client_User_Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_availability_users_User_Id",
                table: "availability",
                column: "User_Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blocked_times_users_User_Id",
                table: "blocked_times",
                column: "User_Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_business_settings_business_Business_Id",
                table: "business_settings",
                column: "Business_Id",
                principalTable: "business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_staff_services_Service_Id",
                table: "service_staff",
                column: "Service_Id",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_staff_users_Staff_User_Id",
                table: "service_staff",
                column: "Staff_User_Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_services_business_Business_Id",
                table: "services",
                column: "Business_Id",
                principalTable: "business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_business_BusinessId",
                table: "users",
                column: "BusinessId",
                principalTable: "business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
