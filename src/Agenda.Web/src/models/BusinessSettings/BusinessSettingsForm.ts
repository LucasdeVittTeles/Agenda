interface BusinessSettingsForm {
    allowOnlineBooking: boolean;
    appointmentApprovalRequired: boolean;
    appointmentIntervalMinutes: number;
    cancelationLimitHours: number;
    maxDailyAppointments: number;
    workingDays: string[];
    themeColor: string;
}