import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";

export default function MainLayout() {
    return (
        <div className="min-h-screen bg-base-200">
            <Navbar />

            <main className="p-6">
                <Outlet />
            </main>
        </div>
    );
}