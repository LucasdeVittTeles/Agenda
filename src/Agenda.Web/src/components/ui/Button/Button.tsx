import type { ButtonHTMLAttributes } from "react";

type ButtonVariant =
    | "primary"
    | "secondary"
    | "outline"
    | "ghost"
    | "error";

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
    variant?: ButtonVariant;
    loading?: boolean;
}

export default function Button({
    children,
    variant = "primary",
    loading = false,
    disabled,
    className = "",
    type = "button",
    ...props
}: ButtonProps) {
    return (
        <button
            type={type}
            disabled={disabled || loading}
            className={`btn btn-${variant} ${className}`}
            {...props}>
            {loading && (
                <span className="loading loading-spinner loading-sm" />
            )}
            {children}
        </button>
    );
}