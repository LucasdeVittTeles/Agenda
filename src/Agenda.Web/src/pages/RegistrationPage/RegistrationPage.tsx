import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { registrationBusiness } from "../../api/registration.api";
import { toast } from "sonner";
import { getApiErrorMessage } from "../../utils/apiError";
import { RegistrationRequest } from "../../models/Registration/RegistrationRequest";
import Input from "../../components/ui/Input/Input";
import Button from "../../components/ui/Button/Button";
import styles from "./RegistrationPage.module.css";
import Card from "../../components/ui/Card/Card";
import { FaSave } from "react-icons/fa";

export default function RegistrationPage() {

    const navigate = useNavigate();

    //dados do proprietario
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [phone, setPhone] = useState("");

    //dados do estabelecimento
    const [businessName, setBusinessName] = useState("");
    const [businessEmail, setBusinessEmail] = useState("");
    const [businessPhone, setBusinessPhone] = useState("");

    const [errors, setErrors] = useState<{
        name?: string;
        email?: string;
        password?: string;
        confirmPassword?: string;
        phone?: string;
        businessName?: string;
        businessEmail?: string;
        businessPhone?: string;
    }>({});

    function validateForm() {

        const newErrors: typeof errors = {};

        if (!name.trim())
            newErrors.name = "Nome é obrigatório.";

        if (!email.trim())
            newErrors.email = "Email é obrigatório.";

        if (!phone.trim()) {
            newErrors.phone = "Contato é obrigatório"
        }

        if (!password.trim()) {
            newErrors.password = "Senha é obrigatório"
        }

        if (password.trim() != confirmPassword.trim()) {
            newErrors.password = "Senhas não conferem"
        }

        if (!businessName.trim())
            newErrors.name = "Nome é obrigatório.";

        if (!businessEmail.trim())
            newErrors.email = "Email é obrigatório.";

        if (!businessPhone.trim()) {
            newErrors.phone = "Contato é obrigatório"
        }

        setErrors(newErrors);

        return Object.keys(newErrors).length === 0;
    }

    async function handleSubmit(event: React.ChangeEvent<HTMLFormElement>) {

        event.preventDefault();

        if (!validateForm())
            return;

        const request: RegistrationRequest = {
            business: {
                name: businessName,
                email: businessEmail,
                phone: businessPhone
            },
            owner: {
                name: name,
                email: email,
                password: password,
                phone: phone,
            }
        };

        try {

            await registrationBusiness(request);
            navigate("/");

        } catch (error) {
            toast.error(getApiErrorMessage(error));
        }

    }

    return (

        <main className="min-h-screen bg-base-200 px-4 py-10">

            <div className="mx-auto w-full max-w-3xl">

                <header className="mb-6 text-center">

                    <div className="mb-4 flex items-center justify-center gap-2 text-primary">
                        <span className="text-2xl font-bold">
                            Agenda
                        </span>
                    </div>

                    <h1 className="text-3xl font-bold text-base-content">
                        Criar sua conta
                    </h1>

                    <p className="mx-auto mt-2 max-w-md text-base-content/60">
                        Cadastre seu negócio e seu usuário proprietário
                        para começar a usar o Agenda.
                    </p>

                </header>

                {/* Card principal */}
                <Card className="w-full rounded-2xl shadow-lg">

                    <form className="flex flex-col gap-5">

                        <section className="rounded-xl border border-base-300 p-5">

                            <div className="mb-6 flex items-center gap-4">
                                <div className="flex h-14 w-14 items-center justify-center rounded-full bg-blue-100 text-primary">
                                </div>

                                <div>
                                    <h2 className="text-lg font-bold">
                                        Dados do negócio
                                    </h2>

                                    <p className="text-sm text-base-content/60">
                                        Informações do seu estabelecimento.
                                    </p>
                                </div>
                            </div>

                            <div className="grid grid-cols-1 gap-5 sm:grid-cols-2">

                                <Input
                                    id="name"
                                    label="Nome do estabelecimento"
                                    placeholder="Digite o nome do estabelecimento"
                                    required
                                    maxLength={255}
                                    disabled={false}
                                    className="border-2 border-primary rounded-sm"
                                />

                                <Input
                                    id="email"
                                    label="E-mail comercial"
                                    type="email"
                                    placeholder="contato@seunegocio.com"
                                    required
                                    maxLength={255}
                                    disabled={false}
                                    className="border-2 border-primary rounded-sm"
                                />

                                <Input
                                    id="phone"
                                    label="Telefone"
                                    placeholder="(51) 91234-5678"
                                    required
                                    maxLength={255}
                                    disabled={false}
                                    className="border-2 border-primary rounded-sm"
                                />


                            </div>

                        </section>

                        {/* Dados do proprietário */}
                        <section className="rounded-xl border border-base-300 p-5">

                            <div className="mb-6 flex items-center gap-4">
                                <div className="flex h-14 w-14 items-center justify-center rounded-full bg-blue-100 text-primary">
                                </div>

                                <div>
                                    <h2 className="text-lg font-bold">
                                        Dados do proprietário
                                    </h2>

                                    <p className="text-sm text-base-content/60">
                                        Este será seu usuário com perfil de Owner.
                                    </p>
                                </div>
                            </div>

                            {/* Inputs do proprietário */}
                            <div className="grid grid-cols-1 gap-5 sm:grid-cols-2">

                                <Input
                                    id="name"
                                    label="Nome completo"
                                    placeholder="Ex: Maria Silva"
                                    required
                                    maxLength={255}
                                    disabled={false}
                                    className="border-2 border-primary rounded-sm"
                                />

                                <Input
                                    id="email"
                                    label="E-mail"
                                    type="email"
                                    placeholder="seu@email.com"
                                    required
                                    maxLength={255}
                                    disabled={false}
                                    className="border-2 border-primary rounded-sm"
                                />

                                <Input
                                    id="password"
                                    label="Senha"
                                    placeholder="Digite sua senha"
                                    type="password"
                                    required
                                    maxLength={255}
                                    disabled={false}
                                    className="border-2 border-primary rounded-sm"
                                />

                                <Input
                                    id="confirmPassword"
                                    label="Confirmar senha"
                                    placeholder="Confirme sua senha"
                                    type="password"
                                    required
                                    maxLength={255}
                                    disabled={false}
                                    className="border-2 border-primary rounded-sm"
                                />

                            </div>

                            {/* Informações sobre a senha */}
                            <div className="mt-5 rounded-lg bg-blue-50 p-4 text-sm text-slate-700">
                                <p className="font-medium">
                                    A senha deve conter:
                                </p>

                                <ul className="ml-5 mt-2 list-disc">
                                    <li>Pelo menos 8 caracteres</li>
                                    <li>Uma letra maiúscula</li>
                                    <li>Uma letra minúscula</li>
                                    <li>Um número</li>
                                </ul>
                            </div>

                        </section>

                        {/* Botão de cadastro */}
                        <div className="flex items-center">

                            <Button variant="primary" type="submit" className="rounded-lg w-"> <FaSave />Criar Conta</Button>

                        </div>

                        {/* Rodapé */}
                        <footer className="text-center text-sm text-base-content/60">
                            <p>
                                Já tem uma conta?
                                <a href="/login" className="ml-1 text-primary underline">
                                    Fazer login
                                </a>
                            </p>

                            <p className="mt-5 text-xs">
                                Ao se cadastrar, você concorda com nossos
                                Termos de Uso e Política de Privacidade.
                            </p>
                        </footer>

                    </form>

                </Card>

            </div>

        </main>
    );

}