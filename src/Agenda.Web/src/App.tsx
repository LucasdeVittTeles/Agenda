
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";

import Callback from "./auth/Callback";
import ProtectedRoute from "./auth/ProtectedRoute";
import Login from "./auth/Login";

import { Toaster } from "sonner";

import ServicesPage from "./pages/ServicesPage/ServicesPage";
import MainLayout from "./components/layout/MainLayout";
import FormServicePage from "./pages/ServicesPage/FormServicePage";
import RegistrationPage from "./pages/RegistrationPage/RegistrationPage";

function Dashboard() {
  return <h1>Dashboard</h1>;
}

export default function App() {
  return (
    <>
      <Toaster richColors position="top-right" />

      <BrowserRouter>
        <Routes>
          {/* Rotas públicas */}
          <Route path="/login" element={<Login />} />
          <Route path="/registration" element={<RegistrationPage />} />
          <Route path="/callback" element={<Callback />} />

          {/* Rotas protegidas */}
          <Route element={<ProtectedRoute />}>
            <Route element={<MainLayout />}>
              <Route path="/" element={<Dashboard />} />
              <Route path="/services" element={<ServicesPage />} />
              <Route path="/services/create" element={<FormServicePage />} />
              <Route path="/services/:serviceId/edit" element={<FormServicePage />} />
            </Route>
          </Route>

          {/* Rota inexistente */}
          <Route path="*" element={<Navigate to="/" replace />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}
