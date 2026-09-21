import { User } from "oidc-client-ts";
import { userManager } from "./oidcConfig";

export function login() {
    return userManager.signinRedirect();
}

export function logout() {
    return userManager.signoutRedirect();
}

export function getUser(): Promise<User | null> {
    return userManager.getUser();
}