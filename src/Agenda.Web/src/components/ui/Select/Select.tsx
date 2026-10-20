import type { SelectHTMLAttributes } from "react";

interface SelectOption {
    value: string;
    label: string;
    aditionalLabel: string;
}

interface SelectProps extends SelectHTMLAttributes<HTMLSelectElement> {
    label?: string;
    adtionalLabel: string;
    error?: string;
    options: SelectOption[];
    placeholder?: string;
}

export default function Select({ label, error, options, placeholder, id, className = "", ...props }: SelectProps) {
    return (
        <div className="flex flex-col gap-1 w-full">
            {label && (
                <label htmlFor={id} className="text-sm font-medium">
                    {label}
                </label>
            )}

            <select
                id={id}
                aria-invalid={Boolean(error)}
                className={`select w-full ${error ? "select-error" : ""} ${className}`}
                {...props}
            >
                {placeholder && (
                    <option value="" disabled>
                        {placeholder}
                    </option>
                )}

                {options.map((option) => (
                    <option key={option.value} value={option.value}>
                        {option.label} {"-" + option.aditionalLabel}
                    </option>
                ))}
            </select>

            {error && (
                <span className="text-error text-xs">
                    {error}
                </span>
            )}
        </div>
    );
}