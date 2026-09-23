import { api } from "./client";
import { Services } from "../models/Services/Services";
import { CreateServiceRequest } from "../models/Services/CreateServiceRequest";
import { UpdateServiceRequest } from "../models/Services/UpdateServiceRequest";

export async function getServices(): Promise<Services[]> {
    const response = await api.get<Services[]>("/services");

    return response.data;
}

export async function getService(id: number): Promise<Services> {
    const response = await api.get<Services>(`/services/${id}`);

    return response.data;
}

export async function createService(
    request: CreateServiceRequest
): Promise<Services> {
    const response = await api.post<Services>("/services", request);

    return response.data;
}

export async function updateService(
    id: number,
    request: UpdateServiceRequest
): Promise<Services> {
    const response = await api.put<Services>(
        `/services/${id}`,
        request
    );

    return response.data;
}

export async function deleteService(id: number): Promise<void> {
    await api.delete(`/services/${id}`);
}