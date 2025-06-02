
import React, { useState } from 'react';
import { useToast } from '@/hooks/use-toast';
import { Status } from '@/types/invitation';
import { acceptInvitation, declineInvitation } from '@/services/data/actionService';

interface ActionButtonsProps {
  status: Status
  amount: number;
  id:string
  onAction: () => void
}

const ActionButtons = ({ status, amount, id ,onAction}: ActionButtonsProps) => {
  const { toast } = useToast();
  const [invitationId,setInvitationId] = useState(id)

  const handleAccept = async () => {
    setInvitationId(id)
    await acceptInvitation(invitationId)
    
    onAction()
    toast({
      title: "Convite aceito!",
    });
  };

  const handleDecline = async () => {
    setInvitationId(id)
    await declineInvitation(invitationId)

    onAction()
    toast({
      title: "Convite recusado",
      variant: "destructive",
    });
  };

  if (status === Status.INVITED) {
    return (
      <div className="flex items-center space-x-3">
      <button
        onClick={handleAccept}
        className="px-6 py-2 bg-orange-500 text-white rounded-md hover:bg-orange-600 transition-colors duration-200 font-medium"
      >
        Accept
      </button>
      <button
        onClick={handleDecline}
        className="px-6 py-2 bg-gray-200 text-gray-700 rounded-md hover:bg-gray-300 transition-colors duration-200 font-medium"
      >
        Decline
      </button>
      <span className="text-lg font-semibold text-gray-900">
        R${amount.toFixed(2)} <span className="text-sm font-normal text-gray-500">Lead Invitation</span>
      </span>
    </div>
    );
  }
};

export default ActionButtons;
