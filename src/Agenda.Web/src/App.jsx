import { BrowserRouter, Routes, Route } from "react-router-dom";
import Callback from "./auth/Callback";
import { login } from "./auth/authService";

function Login() {
  return (
    <div className="flex min-h-screen items-center justify-center">
      <button className="btn btn-primary" onClick={login}>
        Entrar
      </button>
    </div>
  );
}

function Home() {
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