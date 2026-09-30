import { NavLink } from "react-router-dom";
import { getUser } from "../../auth/authService";
import { useEffect, useState } from "react";

export default function Navbar() {


    const [userName, setUserName] = useState<string>("");

    useEffect(() => {
        getUser().then(user => {
            setUserName(user?.profile.name?.toString() ?? "");
        });
    }, []);

    return (
        <div className="navbar bg-base-100 shadow-sm">
            <div className="navbar-start">
                <NavLink to="/" className="text-xl font-bold">
                    Agenda
                </NavLink>
            </div>

            <div className="navbar-center">
                <ul className="menu menu-horizontal px-1 gap-1">
                    <li>
                        <NavLink to="/">
                            Dashboard
                        </NavLink>
                    </li>

                    <li>
                        <NavLink to="/appointments">
                            Agenda
                        </NavLink>
                    </li>

                    <li>
                        <NavLink to="/services">
                            Serviços
                        </NavLink>
                    </li>

                    <li>
                        <NavLink to="/staff">
                            Equipe
                        </NavLink>
                    </li>

                    <li>
                        <NavLink to="/clients">
                            Clientes
                        </NavLink>
                    </li>

                    <li>
                        <NavLink to="/business">
                            Empresa
                        </NavLink>
                    </li>
                </ul>
            </div>

            <div className="navbar-end">
                <button className="btn btn-ghost">
                    Bem vindo, {userName}
                </button>
            </div>

        </div>
    );
}