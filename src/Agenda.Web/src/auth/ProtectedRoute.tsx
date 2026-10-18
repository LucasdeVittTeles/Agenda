import { useEffect, useState } from "react";
import { Navigate, Outlet } from "react-router-dom";
import { getUser } from "./authService";

export default function ProtectedRoute() {
  const [authenticated, setAuthenticated] = useState<boolean | null>(null);

  useEffect(() => {
    let active = true;

    async function checkAuthentication() {
      try {
        
        const user = await getUser();

        if (active) {
          setAuthenticated(!!user && !user.expired);
        }
      } catch {
        if (active) {
          setAuthenticated(false);
        }
      }
    }

    checkAuthentication();

    return () => {
      active = false;
    };
  }, []);

  // Enquanto verifica a sessão
  if (authenticated === null) {
    return (
      <div className="flex min-h-screen items-center justify-center">
        <span className="loading loading-spinner loading-lg text-primary" />
      </div>
    );
  }

  // Sem sessão válida
  if (!authenticated) {
    return <Navigate to="/login" replace />;
  }

  // Sessão válida: libera as rotas filhas
  return <Outlet />;
}