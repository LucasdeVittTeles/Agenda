import { CreateBusinessRequest } from "../models/Registration/CreateBusinessRequest";
import { RegistrationRequest } from "../models/Registration/RegistrationRequest";
import { api } from "./client";


export async function registrationBusiness(request: RegistrationRequest) {

    const response = await api.post<CreateBusinessRequest>("/Registration", request);

    return response.data;
}