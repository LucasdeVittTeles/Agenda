export interface BusinessSettingsResponse {
    allowOnlineBooking: boolean;
    appointmentApprovalRequired: boolean;
    maxDailyAppointments: number;
    cancelationLimitHours: number;
    appointmentIntervalMinutes: number;
    workingDays: string[];
    themeColor: string;
}