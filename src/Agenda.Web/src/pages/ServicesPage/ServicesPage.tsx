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

            <h1 className="text-5xl mb-4">Serviços</h1>

            <div className="overflow-x-auto rounded-box border border-base-content/5 bg-base-100">
                <table className="table">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>decricao</th>
                            <th>Data de duração</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            services.map(service => (
                                <tr>
                                    <td>{service.name}</td>
                                    <td>{service.description}</td>
                                    <td>
                                        {service.defaultDurationMinutes} min
                                    </td>

                                    <td>
                                        {service.is_Active ? (
                                            <span className="badge badge-success">
                                                Ativo
                                            </span>
                                        ) : (
                                            <span className="badge badge-error">
                                                Inativo
                                            </span>
                                        )}
                                    </td>

                                    <td>
                                        <button className="btn btn-sm btn-primary">

                                            Editar
                                        </button>

                                        <button className="btn btn-sm btn-error ml-2">
                                            Excluir
                                        </button>
                                    </td>
                                </tr>
                            ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}