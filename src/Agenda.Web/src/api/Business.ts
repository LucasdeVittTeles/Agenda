import { api } from "./client";
import { getUser } from "../auth/authService";
import { Business } from "../models/Business/Business";
import { UpdateBusinessRequest } from "../models/Business/UpdateBusinessRequest";

const user = await getUser();

export async function getBusiness(): Promise<Business> {

    const response = await api.get<Business>("/business", {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}

export async function updateBusiness(request: UpdateBusinessRequest) {

    const response = await api.put(`/business`, request, {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}