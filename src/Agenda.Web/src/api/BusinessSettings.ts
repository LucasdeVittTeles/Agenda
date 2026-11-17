import { api } from "./client";
import { getUser } from "../auth/authService";
import { CreateBusinessSettingsRequest } from "../models/BusinessSettings/CreateBusinessSettingsRequest";
import { UpdateBusinessSettingsRequest } from "../models/BusinessSettings/UpdateBusinessSettingsRequest";
import { BusinessSettingsResponse } from "../models/BusinessSettings/BusinessSettingsResponse";

const user = await getUser();

export async function get(): Promise<BusinessSettingsResponse> {
    const response = await api.get<BusinessSettingsResponse>("/businessSettings", {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}

export async function create(createBusinessSettingsRequest: CreateBusinessSettingsRequest) {
    const response = await api.post("/businessSettings", createBusinessSettingsRequest, {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}


export async function update(updateBusinessSettingsRequest: UpdateBusinessSettingsRequest) {
    const response = await api.put("/businessSettings", updateBusinessSettingsRequest, {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}