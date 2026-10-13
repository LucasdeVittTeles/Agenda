import type { InputHTMLAttributes } from "react";

interface CheckboxProps
    extends Omit<InputHTMLAttributes<HTMLInputElement>, "type"> {
    label?: string;
    error?: string;
}

export default function Checkbox({
    label,
    error,
    id,
    className = "",
    ...props
}: CheckboxProps) {
    return (
        <div className="flex flex-col gap-1">
            <label className="flex items-center gap-2 cursor-pointer">
                <input
                    {...props}
                    id={id}
                    type="checkbox"
                    aria-invalid={Boolean(error)}
                    aria-describedby={error && id ? `${id}-error` : undefined}
                    className={`checkbox checkbox-primary ${className}`}
                />

                {label && (
                    <span className="text-sm font-medium">
                        {label}
                    </span>
                )}
            </label>

            {error && (
                <span
                    id={id ? `${id}-error` : undefined}
                    className="text-error text-xs"
                >
                    {error}
                </span>
            )}
        </div>
    );
}