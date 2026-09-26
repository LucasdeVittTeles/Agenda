import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useEffect } from "react";

import Callback from "./auth/Callback";
import { login } from "./auth/authService";
import { getServices } from "./api/api";
import ServicesPage from "./pages/ServicesPage/ServicesPage";

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

function Home() {
  return ServicesPage();
}

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/callback" element={<Callback />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;