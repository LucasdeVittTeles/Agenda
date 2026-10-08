import axios from "axios";

interface ProblemDetails {
    title?: string;
    detail?: string;
    status?: number;
}

export function getApiErrorMessage(error: unknown): string {
    if (axios.isAxiosError<ProblemDetails>(error)) {
        const problem = error.response?.data;

        if (problem?.detail)
            return problem.detail;

        if (problem?.title)
            return problem.title;

        if (!error.response)
            return "Não foi possível conectar ao servidor.";
    }

    return "Ocorreu um erro inesperado.";
}
