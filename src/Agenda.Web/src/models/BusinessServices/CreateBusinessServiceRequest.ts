export interface CreateBusinessServiceRequest
{
    name: string;
    description: string;
    defaultDurationMinutes: number;
    isActive: boolean;
}