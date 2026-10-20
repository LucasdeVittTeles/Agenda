import axios from "axios";

const api = axios.create({
    baseURL: "https://servicodados.ibge.gov.br/api/v1/localidades"
});

export interface State {
    id: number;
    sigla: string;
    nome: string;
}

export interface City {
    id: number;
    nome: string;
}

export async function getStates(): Promise<State[]> {
    
    const response = await api.get<State[]>("/estados");

    return response.data.sort((a, b) =>
        a.nome.localeCompare(b.nome)
    );
}

export async function getCities(uf: string): Promise<City[]> {

    const response = await api.get<City[]>(`/estados/${uf}/municipios`);

    return response.data.sort((a, b) =>
        a.nome.localeCompare(b.nome)
    );
}