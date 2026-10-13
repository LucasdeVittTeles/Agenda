import { CreateBusinessRequest } from "./CreateBusinessRequest";
import { CreateOwnerRequest } from "./CreateOwnerRequest";

export interface RegistrationRequest {
    owner: CreateOwnerRequest;
    business: CreateBusinessRequest;
}