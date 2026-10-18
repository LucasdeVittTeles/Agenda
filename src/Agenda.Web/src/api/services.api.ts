import { api } from "./client";
import { Services } from "../models/BusinessServices/Services";
import { CreateBusinessServiceRequest } from "../models/BusinessServices/CreateBusinessServiceRequest";
import { UpdateBusinessServiceRequest } from "../models/BusinessServices/UpdateBusinessServiceRequest";
import { getUser } from "../auth/authService";

const user = await getUser();

export async function getServices(): Promise<Services[]> {

    const response = await api.get<Services[]>("/services", {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}

export async function getService(id: number): Promise<Services> {


    const response = (await api.get<Services>(`/services/${id}`, {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    }));

    return response.data;
}

export async function createBusinessService(request: CreateBusinessServiceRequest): Promise<Services> {

    const response = await api.post<Services>("/services", request, {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}

export async function updateBusinessService(id: number, request: UpdateBusinessServiceRequest): Promise<Services> {

    const response = await api.put<Services>(`/services/${id}`, request, {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });

    return response.data;
}

export async function deleteService(serviceId: number): Promise<void> {
    await api.delete(`/services/${serviceId}`, {
        headers: {
            'Authorization': `Bearer ${user?.access_token}`
        }
    });
}