import { BrowserRouter, Routes, Route } from "react-router-dom";
import Callback from "./auth/Callback";
import { login } from "./auth/authService";
import { useEffect, useState } from "react";
import { getUser } from "./auth/authService";

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
  const [user, setUser] = useState(null);

  useEffect(() => {
    getUser().then(setUser);
  }, []);

  return (
    <div>
      <h1>Agenda</h1>

      <pre>
        {JSON.stringify(user, null, 2)}
      </pre>
    </div>
  );
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