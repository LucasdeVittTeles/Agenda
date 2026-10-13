
import { useState, type InputHTMLAttributes, type ReactNode } from "react";
import { LuEye, LuEyeOff } from "react-icons/lu";

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
    label?: string;
    error?: string;
    icon?: ReactNode;
}

export default function Input({
    label,
    error,
    icon,
    id,
    type = "text",
    className = "",
    ...props
}: InputProps) {
    const [showPassword, setShowPassword] = useState(false);

    const isPassword = type === "password";

    const inputType = isPassword
        ? showPassword ? "text" : "password"
        : type;

    return (
        <div className="flex w-full flex-col gap-1">
            {label && (
                <label
                    htmlFor={id}
                    className="text-sm font-medium"
                >
                    {label}
                </label>
            )}

            <div className="relative">
                {icon && (
                    <span className="pointer-events-none absolute inset-y-0 left-3 flex items-center text-base-content/50">
                        {icon}
                    </span>
                )}

                <input
                    {...props}
                    id={id}
                    type={inputType}
                    aria-invalid={Boolean(error)}
                    aria-describedby={error && id ? `${id}-error` : undefined}
                    className={`
                        input w-full
                        ${icon ? "pl-10" : ""}
                        ${isPassword ? "pr-11" : ""}
                        ${error ? "input-error" : ""}
                        ${className}
                    `}
                />

                {isPassword && (
                    <button
                        type="button"
                        onClick={() => setShowPassword(!showPassword)}
                        aria-label={showPassword ? "Ocultar senha" : "Mostrar senha"}
                        aria-pressed={showPassword}
                        className="absolute inset-y-0 right-3 flex items-center
                                   cursor-pointer text-base-content/50
                                   hover:text-primary transition-colors"
                    >
                        {showPassword ? (
                            <LuEyeOff size={19} />
                        ) : (
                            <LuEye size={19} />
                        )}
                    </button>
                )}
            </div>

            {error && (
                <span
                    id={id ? `${id}-error` : undefined}
                    className="text-xs text-error"
                >
                    {error}
                </span>
            )}
        </div>
    );
}
