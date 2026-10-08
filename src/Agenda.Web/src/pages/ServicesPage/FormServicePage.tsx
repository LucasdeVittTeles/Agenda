import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { createBusinessService, getService, updateBusinessService } from "../../api/services.api";
import { CreateBusinessServiceDTO } from "../../models/Services/CreateBusinessServiceDTO";
import { toast } from "sonner";
import { getApiErrorMessage } from "../../utils/apiError";

export default function FormServicePage() {

    const navigate = useNavigate();

    const { serviceId } = useParams();

    const editingMode = serviceId !== undefined;

    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [defaultDurationMinutes, setDefaultDurationMinutes] = useState(0);
    const [isActive, setIsActive] = useState(true);

    const [errors, setErrors] = useState<{
        name?: string;
        description?: string;
        defaultDurationMinutes?: string;
    }>({});

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

    function validateForm() {
        const newErrors: typeof errors = {};

        if (!name.trim())
            newErrors.name = "Nome é obrigatório.";

        if (!description.trim())
            newErrors.description = "Descrição é obrigatória.";

        if (defaultDurationMinutes <= 0)
            newErrors.defaultDurationMinutes =
                "A duração deve ser maior que zero.";

        setErrors(newErrors);

        return Object.keys(newErrors).length === 0;
    }

    async function handleSubmit(event: React.ChangeEvent<HTMLFormElement>) {

        event.preventDefault();

        if (!validateForm())
            return;

        const request: CreateBusinessServiceDTO = {
            name,
            description,
            defaultDurationMinutes,
            isActive,
        };


        try {

            if (editingMode) {
                await updateBusinessService(Number(serviceId), request);
            } else {
                await createBusinessService(request);
            }

            toast.success(editingMode ? "Serviço editado com sucesso!" : "Serviço criado com sucesso!");

            navigate("/services");

        } catch (error) {
            toast.error(getApiErrorMessage(error));
        }
    }

    return (

        <div className="flex justify-center">

            <div className="card w-96 bg-base-100 card-lg shadow-sm">
                <div className="card-body">
                    <h2 className="card-title">Criar Serviço</h2>

                    <form onSubmit={handleSubmit}>

                        <div className="flex flex-col gap-4">

                            <label className="floating-label">
                                <input type="text"
                                    className={`input ${errors.name ? "input-error" : ""}`}
                                    placeholder="Digite o nome"
                                    value={name}
                                    onChange={(event => setName(event.target.value))}
                                />
                                <span>Nome</span>
                            </label>

                            {errors.name && (
                                <p className="text-error text-sm">
                                    {errors.name}
                                </p>
                            )}

                            <label className="floating-label">
                                <textarea placeholder="Digite uma descrição" className={`textarea ${errors.description ? "textarea-error" : ""}`} value={description} onChange={(event => setDescription(event.target.value))} />
                                <span>Descrição</span>
                            </label>

                            {errors.description && (
                                <p className="text-error text-sm">
                                    {errors.description}
                                </p>
                            )}

                            <label className="floating-label">
                                <input type="text" className={`input ${errors.defaultDurationMinutes ? "input-error" : ""}`} placeholder="Digite a duração em minutos" value={defaultDurationMinutes} onChange={(event => setDefaultDurationMinutes(Number(event.target.value)))} />
                            </label>

                            {errors.defaultDurationMinutes && (
                                <p className="text-error text-sm">
                                    {errors.defaultDurationMinutes}
                                </p>
                            )}

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