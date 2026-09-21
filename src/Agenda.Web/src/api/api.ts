import { getUser } from "../auth/authService";

const API_URL = "http://localhost:5178";

export async function getUsers() {

    const user = await getUser();

    if (!user?.access_token) {
        throw new Error("Usuário não autenticado.");
    }

    const response = await fetch(`${API_URL}/api/users`, {
        method: "GET",
        headers: {
            Authorization: `Bearer ${user.access_token}`,
        },
    });

    if (!response.ok) {
        throw new Error(`Erro na API: ${response.status}`);
    }

    return response.json();
}