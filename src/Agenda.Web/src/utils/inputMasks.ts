
export type InputMask = "cpf" | "cnpj" | "phone" | "cep";

export function applyInputMask(
    value: string,
    mask?: InputMask
): string {
    if (!mask) return value;

    const digits = value.replace(/\D/g, "");

    switch (mask) {
        case "cpf":
            return digits
                .slice(0, 11)
                .replace(/^(\d{3})(\d)/, "$1.$2")
                .replace(/^(\d{3})\.(\d{3})(\d)/, "$1.$2.$3")
                .replace(/\.(\d{3})(\d)/, ".$1-$2");

        case "cnpj":
            return digits
                .slice(0, 14)
                .replace(/^(\d{2})(\d)/, "$1.$2")
                .replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3")
                .replace(/\.(\d{3})(\d)/, ".$1/$2")
                .replace(/(\d{4})(\d)/, "$1-$2");

        case "phone": {
            const phone = digits.slice(0, 11);

            if (phone.length <= 2) {
                return phone.replace(/^(\d{1,2})/, "($1");
            }

            if (phone.length <= 10) {
                return phone
                    .replace(/^(\d{2})(\d)/, "($1) $2")
                    .replace(/(\d{4})(\d)/, "$1-$2");
            }

            return phone
                .replace(/^(\d{2})(\d)/, "($1) $2")
                .replace(/(\d{5})(\d)/, "$1-$2");
        }

        case "cep":
            return digits
                .slice(0, 8)
                .replace(/^(\d{5})(\d)/, "$1-$2");

        default:
            return value;
    }
}
