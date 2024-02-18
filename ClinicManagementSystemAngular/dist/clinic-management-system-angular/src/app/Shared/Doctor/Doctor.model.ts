export class Doctor {
    id!: number;
    name!: string;
    password!: string;
    email!: string;
    userName!: string;
    phone!: string;
    photo!: string; 
    age!: number;
    fees: any;
    education! : string;
    totalRate: any;

    specialty: Specialty = new Specialty;

    reviews: Review[] = [];

}
export class Specialty{
    id!: number;
    name!: string;
}
export class Review{
    rate: any;
    comment!: string;
}