import type { TextareaHTMLAttributes } from "react";

interface TextAreaProps
    extends TextareaHTMLAttributes<HTMLTextAreaElement> {
    label?: string;
    error?: string;
}

export default function TextArea({
    label,
    error,
    id,
    className = "",
    ...props
}: TextAreaProps) {
    return (
        <div className="flex flex-col gap-1 w-full">
            {label && (
                <label htmlFor={id} className="text-sm font-medium">
                    {label}
                </label>
            )}

            <textarea
                id={id}
                aria-invalid={Boolean(error)}
                className={`textarea w-full ${
                    error ? "textarea-error" : ""
                } ${className}`}
                {...props}
            />

            {error && (
                <span className="text-error text-xs">
                    {error}
                </span>
            )}
        </div>
    );
}