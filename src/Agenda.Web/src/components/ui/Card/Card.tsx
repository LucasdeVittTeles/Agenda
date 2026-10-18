import type { HTMLAttributes, ReactNode } from "react";

interface CardProps extends HTMLAttributes<HTMLDivElement> {
    children: ReactNode;
    title?: string;
    description?: string;
}

export default function Card({
    children,
    title,
    description,
    className = "",
    ...props
}: CardProps) {
    return (
        <div
            className={`card bg-base-100 border border-base-300 shadow-sm ${className}`}
            {...props}
        >
            <div className="card-body">
                {title && (
                    <h2 className="card-title text-xl">
                        {title}
                    </h2>
                )}

                {description && (
                    <p className="text-sm text-base-content/60">
                        {description}
                    </p>
                )}

                {children}
            </div>
        </div>
    );
}