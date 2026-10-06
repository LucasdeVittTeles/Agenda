import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { createBusinessService, getService, updateBusinessService } from "../../api/services.api";
import { CreateBusinessServiceDTO } from "../../models/Services/CreateBusinessServiceDTO";

export default function FormServicePage() {

    const navigate = useNavigate();

    const { serviceId } = useParams();

    const editingMode = serviceId !== undefined;

    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [defaultDurationMinutes, setDefaultDurationMinutes] = useState(0);
    const [isActive, setIsActive] = useState(true);


    useEffect(() => {
        if (!editingMode)
            return;

        getService(Number(serviceId))
            .then(service => {
                setName(service.name),
                    setDescription(service.description),
                    setDefaultDurationMinutes(service.defaultDurationMinutes),
                    setIsActive(service.is_Active)
            })
    }, [serviceId, editingMode])

    async function handleSubmit(event: React.ChangeEvent<HTMLFormElement>) {

        event.preventDefault();

        const request: CreateBusinessServiceDTO = {
            name,
            description,
            defaultDurationMinutes,
            isActive,
        };

        if (editingMode) {
            await updateBusinessService(Number(serviceId), request);
        } else {
            await createBusinessService(request);
        }

        navigate("/services");

    }

    return (

        <div className="flex justify-center">

            <div className="card w-96 bg-base-100 card-lg shadow-sm">
                <div className="card-body">
                    <h2 className="card-title">Criar Serviço</h2>

                    <form onSubmit={handleSubmit}>

                        <div className="flex flex-col gap-4">

                            <label className="floating-label">
                                <input type="text" className="input" placeholder="Digite o nome" value={name} onChange={(event => setName(event.target.value))} />
                                <span>Nome</span>
                            </label>
                            <label className="floating-label">
                                <textarea placeholder="Digite uma descrição" className="textarea" value={description} onChange={(event => setDescription(event.target.value))} />
                                <span>Descrição</span>
                            </label>
                            <label className="input">
                                <input type="text" placeholder="Digite a duração em minutos" value={defaultDurationMinutes} onChange={(event => setDefaultDurationMinutes(Number(event.target.value)))} />
                            </label>

                            <div className="flex gap-2">

                                <label>Ativo</label>

                                <input type="checkbox" className="toggle toggle-primary" checked={isActive} onChange={(event => setIsActive(event.target.checked))} />
                            </div>
                        </div>

                        <button className="btn btn-primary mt-2" type="submit">
                            Salvar
                        </button>

                    </form>
                </div>
            </div>
        </div>
    );
}