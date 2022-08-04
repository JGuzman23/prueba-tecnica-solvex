export interface Cliente{
    id: number;
    name: string;
    lastName: string;
    email:string
    password:string;
    cellPhone:string
    isActive:boolean;
}

export class Initialize{
    public static User:Cliente={ 
    id: 0,
    name: "",
    lastName: "",
    email:"",
    password:"",
    cellPhone:"",
    isActive:true
}}