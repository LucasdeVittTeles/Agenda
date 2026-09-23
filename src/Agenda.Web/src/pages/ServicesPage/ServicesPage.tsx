import { useEffect, useState } from "react";
import { getServices } from "../../api/services.api";
import { Services } from "../../models/Services/Services";

export default function ServicesPage() {
    const [services, setServices] = useState<Services[]>([]);

    useEffect(() => {
        getServices()
            .then(data => {
                setServices(data);
            })
            .catch(error => {
                console.error(error);
            });
    }, []);

    return (
        <div>
            <h1>Serviços</h1>

            {services.map(service => (
                <div key={service.id}>
                    <strong>{service.name}</strong>
                    <span>{service.description}</span>
                </div>
            ))}
        </div>
    );
}