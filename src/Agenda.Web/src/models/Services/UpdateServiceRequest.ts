export interface UpdateServiceRequest 
{
    name: string;
    description: string;
    default_duration_minutes: number;
    is_active: boolean;
}