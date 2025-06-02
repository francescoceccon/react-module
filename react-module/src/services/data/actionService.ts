import { Invitation, Status } from '@/types/invitation';
import axios from 'axios';

export const fetchInvitations = async (status: Status.ACCEPTED | Status.INVITED): Promise<Invitation[]> => {
  const endpoint = status === Status.INVITED
    ? 'http://localhost:5000/api/Leads/Invited'
    : 'http://localhost:5000/api/Leads/Accepted';

  const response = await axios.get<Invitation[]>(endpoint);
  return response.data;
};

export const acceptInvitation = async (id: string) => {
  try {
    const response = await axios.post(
      'http://localhost:5000/api/Leads/Accept',
      { leadId: id },
      {
        headers: {
          'Content-Type': 'application/json',
        },
      }
    );

    console.log('Dados recebidos:', response.data);
    return response.data;
  } catch (error) {
    console.error('Erro na requisição:', error);
    throw error;
  }
};

export const declineInvitation = async (id: string) => {
  try {
    const response = await axios.post(
      'http://localhost:5000/api/Leads/Decline',
      { leadId: id },
      {
        headers: {
          'Content-Type': 'application/json',
        },
      }
    );

    console.log('Dados recebidos:', response.data);
    return response.data;
  } catch (error) {
    console.error('Erro na requisição:', error);
    throw error;
  }
};

