import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { UpdateBusinessRequest } from "../../models/Business/UpdateBusinessRequest";
import { toast } from "sonner";
import { getApiErrorMessage } from "../../utils/apiError";
import { updateBusiness } from "../../api/Business";
import { FaMapMarkerAlt, FaSave } from "react-icons/fa";
import Card from "../../components/ui/Card/Card";
import Input from "../../components/ui/Input/Input";
import Button from "../../components/ui/Button/Button";
import Select, { SelectOption } from "../../components/ui/Select/Select";
import { getCities, getStates } from "../../api/ibgeApi";
import { IoIosBusiness } from "react-icons/io";

export default function FormBusinessPage() {

    const navigate = useNavigate();

    //dados principais do estabelecimento
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [phone, setPhone] = useState("");
    const [document, setDocument] = useState("");
    const [whatsapp, setWhatsapp] = useState("");
    const [logoUrl, setLogoUrl] = useState("");

    //dados de localidade

    const [zipCode, setZipCode] = useState("");
    const [street, setStreet] = useState("");
    const [number, setNumber] = useState("");
    const [district, setDistrict] = useState("");
    const [city, setCity] = useState("");
    const [state, setState] = useState("");

    const [errors, setErrors] = useState<{
        name?: string;
        email?: string;
        phone?: string;
    }>({});

    type BusinessTab = "main" | "address";
    const [activeTab, setActiveTab] = useState<BusinessTab>("main");
    const [statesList, setStatesList] = useState<SelectOption[]>([]);
    const [citiesList, setCitiesList] = useState<SelectOption[]>([]);

    function validateForm() {

        const newErrors: typeof errors = {};

        if (!name.trim())
            newErrors.name = "Nome é obrigatório.";

        if (!email.trim())
            newErrors.email = "Email é obrigatório.";

        if (!phone.trim()) {
            newErrors.phone = "Telefone é obrigatório"
        }

        setErrors(newErrors);

        return Object.keys(newErrors).length === 0;
    }

    function clearError(field: keyof typeof errors) {
        setErrors((prev) => ({
            ...prev,
            [field]: undefined
        }));
    }

    useEffect(() => {

        async function loadStates() {
            try {
                const response = await getStates();

                const options: SelectOption[] = response.map((item) => ({
                    label: item.nome,
                    value: item.sigla,
                    aditionalLabel: item.sigla
                }));

                setStatesList(options);
            } catch {
                toast.error("Erro ao carregar estados.");
            }
        }

        void loadStates();

    }, []);


    useEffect(() => {

        async function loadCities() {
            try {

                const response = await getCities(state);

                const options: SelectOption[] = response.map((item) => ({
                    label: item.nome,
                    value: item.id.toString(),
                }));

                setCitiesList(options);
            } catch {
                toast.error("Erro ao carregar estados.");
            }
        }

        void loadCities();

    }, [state]);

    async function handleSubmit(event: React.ChangeEvent<HTMLFormElement>) {

        event.preventDefault();

        if (!validateForm())
            return;

        const request: UpdateBusinessRequest = {
            name,
            email,
            phone,
            document,
            whatsapp,
            logo_Url: logoUrl,
            zip_Code: zipCode,
            street,
            number,
            district,
            city,
            state,
        };

        try {

            await updateBusiness(request);

            toast.success("Empresa editada com sucesso!");

            navigate("/");

        } catch (error) {
            toast.error(getApiErrorMessage(error));
        }
    }


    const searchZipCode = async () => {

        const cep = zipCode.replace(/\D/g, "");

        if (cep.length !== 8) {
            toast.error("CEP inválido.");
            return;
        }

        try {
            const response = await fetch(
                `https://viacep.com.br/ws/${cep}/json/`
            );

            if (!response.ok) {
                throw new Error("Erro ao consultar CEP.");
            }

            const data = await response.json();

            if (data.erro) {
                toast.error("CEP não encontrado.");
                return;
            }

            setStreet(data.logradouro);
            setDistrict(data.bairro);
            setCity(data.localidade);
            setState(data.uf);

        } catch {
            toast.error("Não foi possível consultar o CEP.");
        }

    }


    return (

        <main className="min-h-screen bg-base-200 px-4 py-10">

            <div className="mx-auto w-full max-w-5xl">

                <Card className="w-full rounded-2xl shadow-lg">


                    <div role="tablist" className="tabs tabs-border mb-6">

                        <button
                            type="button"
                            role="tab"
                            aria-selected={activeTab === "main"}
                            className={`tab ${activeTab === "main" ? "tab-active" : ""}`}
                            onClick={() => setActiveTab("main")}
                        >
                            Dados principais
                        </button>

                        <button
                            type="button"
                            role="tab"
                            aria-selected={activeTab === "address"}
                            className={`tab ${activeTab === "address" ? "tab-active" : ""}`}
                            onClick={() => setActiveTab("address")}
                        >
                            Dados de localidade
                        </button>

                    </div>

                    <form onSubmit={handleSubmit} noValidate className="flex flex-col gap-5">

                        {activeTab === "main" && (
                            <>

                                <div className="mb-6 flex items-center gap-4">
                                    <div className="flex h-14 w-14 items-center justify-center rounded-full bg-blue-100 text-primary">
                                        <IoIosBusiness size={32} />
                                    </div>
                                    <div>
                                        <h2 className="text-lg font-bold">
                                            Dados principais
                                        </h2>
                                        <p className="text-sm text-base-content/60">
                                            Informações básicas do seu estabelecimento.
                                        </p>
                                    </div>
                                </div>


                                <Input
                                    id="name"
                                    label="Nome"
                                    placeholder="Digite o nome do estabelecimento"
                                    required
                                    value={name}
                                    error={errors.name}
                                    onChange={(event) => {
                                        setName(event.target.value)
                                        clearError("name");
                                    }}
                                    maxLength={255}
                                    disabled={false}
                                />

                                <Input
                                    id="email"
                                    label="E-mail"
                                    placeholder="Digite o e-mail do estabelecimento"
                                    required
                                    type="email"
                                    value={email}
                                    error={errors.email}
                                    onChange={(event) => {
                                        setEmail(event.target.value)
                                        clearError("email");
                                    }}
                                    maxLength={255}
                                    disabled={false}
                                />

                                <div className="flex gap-3">

                                    <Input
                                        id="phone"
                                        label="Telefone"
                                        placeholder="(51) 91234-5678"
                                        required
                                        mask="phone"
                                        value={phone}
                                        error={errors.phone}
                                        onChange={(event) => {
                                            setPhone(event.target.value);
                                            clearError("phone");
                                        }}
                                        maxLength={255}
                                        disabled={false}
                                    />



                                    <Input
                                        id="whatsapp"
                                        label="WhatsApp"
                                        placeholder="(51) 91234-5678"
                                        mask="phone"
                                        value={whatsapp}
                                        onChange={(event) => {
                                            setWhatsapp(event.target.value);
                                        }}
                                        maxLength={255}
                                        disabled={false}
                                    />


                                </div>

                                <Input
                                    id="document"
                                    label="Documento (CNPJ)"
                                    placeholder="12.345.678/0001-XX"
                                    mask="cnpj"
                                    value={document}
                                    onChange={(event) => {
                                        setDocument(event.target.value);
                                    }}
                                    maxLength={255}
                                    disabled={false}
                                />

                            </>
                        )}

                        {activeTab === "address" && (

                            <>

                                <div className="mb-6 flex items-center gap-4">
                                    <div className="flex h-14 w-14 items-center justify-center rounded-full bg-blue-100 text-primary">
                                        <FaMapMarkerAlt size={32} />
                                    </div>
                                    <div>
                                        <h2 className="text-lg font-bold">
                                            Dados de localidade
                                        </h2>
                                        <p className="text-sm text-base-content/60">
                                            endereço do seu estabelecimento.
                                        </p>
                                    </div>
                                </div>



                                <Input
                                    id="zipCode"
                                    label="CEP"
                                    placeholder="Digite o CEP do estabelecimento"
                                    mask="cep"
                                    value={zipCode}
                                    onChange={(event) => {
                                        setZipCode(event.target.value)
                                        searchZipCode();
                                    }}
                                    maxLength={255}
                                    disabled={false}
                                />

                                <div className="flex w-full gap-3">
                                    <div className="min-w-0 flex-1">
                                        <Input
                                            id="street"
                                            label="Rua"
                                            placeholder="Digite o nome da rua"
                                            value={street}
                                            onChange={(event) => {
                                                setStreet(event.target.value)
                                            }}
                                            maxLength={255}
                                            disabled={false}
                                        />
                                    </div>

                                    <div className="w-75 shrink-0">
                                        <Input
                                            id="number"
                                            label="Numero"
                                            placeholder="Digite o numero"
                                            value={number}
                                            onChange={(event) => {
                                                setNumber(event.target.value)
                                            }}
                                            maxLength={255}
                                            disabled={false}
                                        />
                                    </div>

                                </div>

                                <Input
                                    id="district"
                                    label="Bairro"
                                    placeholder="Digite o nome do bairro"
                                    value={district}
                                    onChange={(event) => {
                                        setDistrict(event.target.value)
                                    }}
                                    maxLength={255}
                                    disabled={false}
                                />

                                <Select
                                    id="state"
                                    label="Estado"
                                    options={statesList}
                                    placeholder="Selecione o estado"
                                    value={state}
                                    onChange={(event) => setState(event.target.value)}
                                />

                                <Select
                                    id="city"
                                    label="Cidade"
                                    options={citiesList}
                                    placeholder="Selecione a cidade"
                                    value={city}
                                    onChange={(event) => setCity(event.target.value)}
                                />


                            </>
                        )}


                        <Button variant="primary" type="submit" className="rounded-lg w-full"> <FaSave />Criar Conta</Button>

                    </form>

                </Card>


            </div>


        </main>
    )


}