import { Status } from "./status";

export interface Invitation {
  id: string;
  jobId: number;
  firstName: string;
  lastName: string;
  suburb: string;
  category: string;
  description: string;
  price: number;
  status: Status;
  phone:string
  email:string
  createdAt:string
}

export { Status };

