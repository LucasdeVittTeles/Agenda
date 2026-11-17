export interface CreateBusinessSettingsRequest {
    allow_Online_Booking: boolean;
    Appointment_Approval_Required: boolean;
    Max_Daily_Appointments: number;
    Cancelation_Limit_Hours: number;
    Appointment_Interval_Minutes: number;
    Working_Days: string[];
    Theme_Color: string;
}