import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react"
import { get } from "../../api/BusinessSettings";
import { toast } from "sonner";

export default function BusinessSettingsPage() {

    const navigate = useNavigate();


    const [form, setForm] = useState<BusinessSettingsForm>({
        allowOnlineBooking: true,
        appointmentApprovalRequired: false,
        appointmentIntervalMinutes: 30,
        cancelationLimitHours: 24,
        maxDailyAppointments: 10,
        workingDays: [],
        themeColor: "#000000"
    });

    const handleChange = (field: keyof BusinessSettingsForm, value: string | number | boolean) => {
        setForm(prev => ({
            ...prev,
            [field]: value
        }));
    };

    useEffect(() => {

        async function getBusinessSettings() {

            try {

                const response = await get();

                setForm({
                    allowOnlineBooking: response.allowOnlineBooking,
                    appointmentApprovalRequired: response.appointmentApprovalRequired,
                    appointmentIntervalMinutes: response.appointmentIntervalMinutes,
                    cancelationLimitHours: response.cancelationLimitHours,
                    maxDailyAppointments: response.maxDailyAppointments,
                    workingDays: response.workingDays,
                    themeColor: response.themeColor,
                });

            } catch {
                toast.error("Erro ao buscar configuração da empresa");
            }
        }

    }, []);


    return
    (
        <></>
    )


}