export interface AuthResponse{
    ok:boolean;
    token: string;
    id: number;
    fullName: string;
    access: string;
    username: string;
    isValid:boolean;
}