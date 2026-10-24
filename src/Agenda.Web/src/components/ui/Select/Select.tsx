
import type { SelectHTMLAttributes } from "react";
import { twMerge } from "tailwind-merge";

export interface SelectOption {
    value: string;
    label: string;
    aditionalLabel?: string;
}

interface SelectProps extends SelectHTMLAttributes<HTMLSelectElement> {
    label?: string;
    error?: string;
    options: SelectOption[];
    placeholder?: string;
}

const defaultSelectStyles = `
    select
    w-full
    h-12
    rounded-lg
    border
    border-base-300
    bg-base-100
    text-base-content
    text-sm
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

export default function Select({
    label,
    error,
    options,
    placeholder,
    id,
    className = "",
    value,
    ...props
}: SelectProps) {
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

            <select
                {...props}
                id={id}
                value={value}
                aria-invalid={Boolean(error)}
                aria-describedby={
                    error && id ? `${id}-error` : undefined
                }
                className={twMerge(
                    defaultSelectStyles,
                    value === "" && "text-base-content/40",
                    error &&
                        "border-error focus:border-error focus:ring-error/20",
                    className
                )}
            >
                {placeholder && (
                    <option value="" disabled>
                        {placeholder}
                    </option>
                )}

                {options.map((option) => (
                    <option
                        key={option.value}
                        value={option.value}
                    >
                        {option.label}
                        {option.aditionalLabel
                            ? ` - ${option.aditionalLabel}`
                            : ""}
                    </option>
                ))}
            </select>

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
