import { useEffect, useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";

import { getApiErrorMessage } from "../../utils/apiError";
import { getBusiness, updateBusiness } from "../../api/Business";
import { getCities, getStates } from "../../api/ibgeApi";

import { UpdateBusinessRequest } from "../../models/Business/UpdateBusinessRequest";

import Card from "../../components/ui/Card/Card";
import Input from "../../components/ui/Input/Input";
import Button from "../../components/ui/Button/Button";
import Select, { SelectOption } from "../../components/ui/Select/Select";

import { FaMapMarkerAlt, FaSave, FaTrashAlt } from "react-icons/fa";
import { IoIosBusiness } from "react-icons/io";
import { PiWarningCircle } from "react-icons/pi";
import { CiImageOn } from "react-icons/ci";
import { MdOutlineFileUpload } from "react-icons/md";


export default function FormBusinessPage() {

    const navigate = useNavigate();

    const fileInputRef = useRef<HTMLInputElement>(null);

    type BusinessTab = "main" | "address";

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

    const [selectedLogo, setSelectedLogo] = useState<File | null>(null);
    const [logoPreview, setLogoPreview] = useState<string | null>(null);
    const [pendingCity, setPendingCity] = useState("");

    const [errors, setErrors] = useState<{
        name?: string;
        email?: string;
        phone?: string;
    }>({});

    const [activeTab, setActiveTab] = useState<BusinessTab>("main");
    const [statesList, setStatesList] = useState<SelectOption[]>([]);
    const [citiesList, setCitiesList] = useState<SelectOption[]>([]);


    useEffect(() => {

        async function loadBusiness() {
            try {
                const response = await getBusiness();

                setName(response.name)
                setEmail(response.email)
                setPhone(response.phone)
                setDocument(response.document)
                setWhatsapp(response.whatsapp)
                setZipCode(response.zip_Code)
                setStreet(response.street)
                setNumber(response.number)
                setDistrict(response.district)
                setCity(response.city)
                setState(response.state)

            } catch (error) {
                toast.error("Erro ao carregar dados da empresa.");
            }
        }

        void loadBusiness();

    }, []);

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

    useEffect(() => {

        if (!selectedLogo) {
            setLogoPreview(null);
            return;
        }

        const url = URL.createObjectURL(selectedLogo);

        setLogoPreview(url);

        return () => URL.revokeObjectURL(url);

    }, [selectedLogo])

    useEffect(() => {

        const cleanCep = zipCode.replace(/\D/g, "");

        if (cleanCep.length !== 8) return;

        const timeout = setTimeout(() => {
            searchZipCode();
        }, 500);

        return () => clearTimeout(timeout);
    }, [zipCode]);

    useEffect(() => {
        if (!pendingCity || citiesList.length === 0) return;

        const cityValue = citiesList.find(
            city => city.label === pendingCity
        )?.value;

        setCity(cityValue ?? "");
        setPendingCity("");
    }, [citiesList, pendingCity]);

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
            logo_Url: "",
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

    function handleLogoChange(event: React.ChangeEvent<HTMLInputElement>) {

        const file = event.target.files?.[0];

        if (!file) {
            return;
        }

        const allowedTypes = ["image/png", "image/jpeg"];

        const maxSize = 2 * 1024 * 1024;

        if (!allowedTypes.includes(file.type)) {
            toast.error("Selecione uma imagem PNG, JPG ou JPEG.");
            event.target.value = "";
            return;
        }

        if (file.size > maxSize) {
            toast.error("A imagem deve ter no máximo 2 MB.");
            event.target.value = "";
            return;
        }

        setSelectedLogo(file);

        setLogoPreview((previous) => {
            if (previous) URL.revokeObjectURL(previous);
            return URL.createObjectURL(file);
        });

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
            setState(data.uf);
            setCity("");
            setPendingCity(data.localidade);

        } catch {
            toast.error("Não foi possível consultar o CEP.");
        }
    }

    return (

        <main className="min-h-screen bg-base-200 px-4 py-10">
            <div className="mx-auto w-full max-w-7xl">
                <Card className="w-full rounded-2xl shadow-lg">
                    <div role="tablist" className="tabs tabs-border mb-6">
                        <button
                            type="button"
                            role="tab"
                            aria-selected={activeTab === "main"}
                            className={`tab ${activeTab === "main" ? "tab-active text-primary" : ""}`}
                            onClick={() => setActiveTab("main")}
                        >
                            Dados principais
                        </button>

                        <button
                            type="button"
                            role="tab"
                            aria-selected={activeTab === "address"}
                            className={`tab ${activeTab === "address" ? "tab-active text-primary" : ""}`}
                            onClick={() => setActiveTab("address")}
                        >
                            Dados de localidade
                        </button>
                    </div>

                    <form onSubmit={handleSubmit} noValidate className="flex flex-col gap-5">
                        {activeTab === "main" && (
                            <div className="grid grid-cols-1 gap-4 lg:grid-cols-5">
                                <div className="lg:col-span-3 flex flex-col gap-4">
                                    <div className="flex justify-between">

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

                                    </div>


                                    <Input
                                        id="name"
                                        label="Nome"
                                        placeholder="Digite o nome do estabelecimento"
                                        required
                                        className="mb-4"
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
                                        className="mb-4"
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
                                            className="mb-4"
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
                                        className="mb-4"
                                        mask="cnpj"
                                        value={document}
                                        onChange={(event) => {
                                            setDocument(event.target.value);
                                        }}
                                        maxLength={255}
                                        disabled={false}
                                    />

                                </div>

                                <div className="lg:col-span-2 grid min-h-0 grid-rows-[auto_minmax(0,1fr)] gap-4">

                                    <div className="flex items-center gap-4 bg-blue-100 text-primary rounded-lg p-3 border-1">

                                        <PiWarningCircle size={24} />

                                        <div>
                                            <h2 className="text-sm font-bold">
                                                Mantenha seus dados atualizados.
                                            </h2>
                                            <p className="text-sm text-base-content/60">
                                                Essas informações serão exibidas para seus clientes no agendamento.
                                            </p>
                                        </div>
                                    </div>

                                    <div className="grid min-h-0 grid-rows-[auto_auto_minmax(0,1fr)] rounded-lg border border-base-300 p-4">
                                        <h2 className="text-sm text-primary font-bold">
                                            Logo da empresa
                                        </h2>

                                        <p className="grow-0">
                                            Adicione a logo que será exibida para seus clientes.
                                        </p>

                                        <div className="relative mt-4 flex min-h-0 flex-col items-center justify-center rounded-lg border-2 border-dashed border-primary p-4">

                                            <input
                                                ref={fileInputRef}
                                                type="file"
                                                accept="image/png,image/jpeg"
                                                className="hidden"
                                                onChange={handleLogoChange}
                                            />

                                            {logoPreview ? (<FaTrashAlt color="red" size={24} className="absolute right-2 top-2 m-2 cursor-pointer" onClick={() => setSelectedLogo(null)} />) : <></>}

                                            {logoPreview ?
                                                (
                                                    <img
                                                        src={logoPreview}
                                                        alt="Pré-visualização da logo"
                                                        className="h-24 w-24 rounded-lg object-contain"
                                                    />
                                                ) : (


                                                    <div className="flex h-14 w-14 items-center justify-center rounded-full bg-blue-100 text-primary">
                                                        <CiImageOn size={32} />
                                                    </div>
                                                )
                                            }

                                            <p className="grow-0">Selecione uma imagem</p>

                                            <p className="grow-0">PNG, JPG ou JPEG (Máx. 2MB)</p>

                                            <Button className="rounded-lg" onClick={() => fileInputRef.current?.click()}>
                                                <MdOutlineFileUpload size={20} />
                                                {selectedLogo ? "Alterar imagem" : "Escolher imagem"}
                                            </Button>
                                        </div>



                                    </div>

                                </div>


                            </div>
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

                        <div className="flex justify-end gap-4">

                            <Button variant="secondary" type="button" className="rounded-lg border-none" onClick={() => navigate("/")} >Cancelar</Button>
                            <Button variant="primary" type="submit" className="rounded-lg"> <FaSave />Salvar</Button>
                        </div>

                    </form>

                </Card>

            </div>

        </main>
    )
}