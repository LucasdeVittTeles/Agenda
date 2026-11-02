import { api } from "./client";
import { getUser } from "../auth/authService";
import { Business } from "../models/Business/Business";

const user = await getUser();

export async function getBusiness(): Promise<Business> {
    const response = await api.get<Business>("/business", {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}

export async function getBusinessLogo(): Promise<Blob> {
    const response = await api.get("/business/logo", {
        responseType: "blob",
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}

export async function updateBusiness(formData: FormData) {
    const response = await api.put("/business", formData, {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}