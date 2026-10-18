
import {
    useState,
    type ChangeEvent,
    type InputHTMLAttributes,
    type ReactNode
} from "react";

import { LuEye, LuEyeOff } from "react-icons/lu";
import { twMerge } from "tailwind-merge";

import {
    applyInputMask,
    type InputMask
} from "../../../utils/inputMasks";

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
    label?: string;
    error?: string;
    icon?: ReactNode;
    mask?: InputMask;
}

const defaultInputStyles = `
    input
    w-full
    h-12
    rounded-lg
    border
    border-base-300
    bg-base-100
    text-base-content
    text-sm
    placeholder:text-base-content/40
    transition-colors
    duration-200
    focus:outline-none
    focus:border-primary
    focus:ring-2
    focus:ring-primary/20
    disabled:bg-base-200
    disabled:cursor-not-allowed
    disabled:opacity-60
`;

export default function Input({
    label,
    error,
    icon,
    mask,
    id,
    type = "text",
    className = "",
    value,
    defaultValue,
    onChange,
    ...props
}: InputProps) {
    const [showPassword, setShowPassword] = useState(false);

    const isPassword = type === "password";

    const inputType = isPassword
        ? showPassword ? "text" : "password"
        : type;

    function handleChange(event: ChangeEvent<HTMLInputElement>) {
        if (mask) {
            event.target.value = applyInputMask(
                event.target.value,
                mask
            );
        }

        onChange?.(event);
    }

    return (
        <div className="flex w-full flex-col gap-1.5">
            {label && (
                <label
                    htmlFor={id}
                    className="text-sm font-medium text-base-content"
                >
                    {label}
                </label>
            )}

            <div className="relative">
                {icon && (
                    <span
                        className="pointer-events-none absolute inset-y-0 left-3 flex items-center text-base-content/50"
                    >
                        {icon}
                    </span>
                )}

                <input
                    {...props}
                    id={id}
                    type={inputType}
                    value={
                        mask && value != null
                            ? applyInputMask(String(value), mask)
                            : value
                    }
                    defaultValue={
                        mask && defaultValue != null
                            ? applyInputMask(String(defaultValue), mask)
                            : defaultValue
                    }
                    onChange={handleChange}
                    inputMode={mask ? "numeric" : props.inputMode}
                    aria-invalid={Boolean(error)}
                    aria-describedby={
                        error && id ? `${id}-error` : undefined
                    }
                    className={twMerge(
                        defaultInputStyles,
                        icon && "pl-10",
                        isPassword && "pr-11",
                        error && "border-error focus:border-error focus:ring-error/20",
                        className
                    )}
                />

                {isPassword && (
                    <button
                        type="button"
                        disabled={props.disabled}
                        onClick={() => setShowPassword(!showPassword)}
                        aria-label={
                            showPassword ? "Ocultar senha" : "Mostrar senha"
                        }
                        aria-pressed={showPassword}
                        className="absolute inset-y-0 right-3 flex cursor-pointer items-center text-base-content/50 transition-colors hover:text-primary disabled:cursor-not-allowed"
                    >
                        {showPassword
                            ? <LuEyeOff size={19} />
                            : <LuEye size={19} />}
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
