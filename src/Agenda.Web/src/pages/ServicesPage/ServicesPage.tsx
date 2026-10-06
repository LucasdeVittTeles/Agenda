import { useEffect, useState } from "react";
import { deleteService, getServices } from "../../api/services.api";
import { Services } from "../../models/Services/Services";
import { useNavigate } from "react-router-dom";

export default function ServicesPage() {

    const navigate = useNavigate();
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

    async function handleDelete(serviceId: number) {
        try {

            await deleteService(serviceId);

            setServices(currentServices =>
                currentServices.filter(service => service.id !== serviceId)
            );
        } catch (error) {
            console.error("Erro ao excluir serviço:", error);
        }
    }

    return (
        <div>

            <div className="flex space-x-400">
                <h1 className="text-5xl mb-4">Serviços</h1>
                <button className="btn btn-primary" onClick={() => navigate("/services/create")}>Adiconar</button>
            </div>

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
                                        <button className="btn btn-sm btn-primary" onClick={() => navigate(`/services/${service.id}/edit`)}>
                                            Editar
                                        </button>

                                        <button onClick={() => handleDelete(service.id)} className="btn btn-sm btn-error ml-2">
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