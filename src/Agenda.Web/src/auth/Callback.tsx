import { useEffect } from "react";
import { userManager } from "./oidcConfig";

export default function Callback() {
    useEffect(() => {
        userManager.signinCallback()
            .then(() => {
                window.location.href = "/";
            })
            .catch((error) => {
                console.error("Erro no callback de autenticação:", error);
            });
    }, []);

    return <p>Finalizando login...</p>;
}