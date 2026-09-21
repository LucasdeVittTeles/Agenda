import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useEffect } from "react";

import Callback from "./auth/Callback";
import { login } from "./auth/authService";
import { getUsers } from "./api/api";

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
  console.log("HOME FOI MONTADO");

  useEffect(() => {
    console.log("USE EFFECT EXECUTOU");

    getUsers()
      .then((data) => {
        console.log("RESPOSTA DA API:", data);
      })
      .catch((error) => {
        console.error("ERRO DA API:", error);
      });

  }, []);

  return <h1>Agenda</h1>;
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