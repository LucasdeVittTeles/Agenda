import { BrowserRouter, Routes, Route } from "react-router-dom";

import Callback from "./auth/Callback";
import { login } from "./auth/authService";

import ServicesPage from "./pages/ServicesPage/ServicesPage";
import MainLayout from "./components/layout/MainLayout";
import FormServicePage from "./pages/ServicesPage/FormServicePage";

function Login() {
  return (
    <div className="flex min-h-screen items-center justify-center">
      <button
        className="btn btn-primary"
        onClick={login}
      >
        Entrar
      </button>
    </div>
  );
}

function Dashboard() {
  return <h1>Dashboard</h1>;
}

export default function App() {
  return (
    <BrowserRouter>
      <Routes>

        {/* Rotas sem layout */}
        <Route
          path="/login"
          element={<Login />}
        />

        <Route
          path="/callback"
          element={<Callback />}
        />

        {/* Rotas do sistema */}
        <Route element={<MainLayout />}>

          <Route
            path="/"
            element={<Dashboard />}
          />

          <Route path="/services" element={<ServicesPage />} />
          <Route path="/services/create" element={<FormServicePage />} />

        </Route>

      </Routes>
    </BrowserRouter>
  );
}