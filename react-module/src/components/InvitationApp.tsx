
import { useEffect, useState } from 'react';
import TabNavigation from './TabNavigation';
import InvitationList from './InvitationList';
import { fetchInvitations } from '../services/data/actionService';
import { Invitation, Status } from '@/types/invitation';
import { useToast } from '@/hooks/use-toast';

export default function InvitationApp(){

  const [activeTab, setActiveTab] = useState(Status.INVITED);
  const [invitations, setInvitations] = useState<Invitation[]>([]);
  const [loading, setLoading] = useState(true);
  const { toast } = useToast();

  const handleInvitationAction = (id: string) => {
    setInvitations(prev => prev.filter(invite => invite.id !== id));
  };

  useEffect(() => {
    const loadInvitations = async () => {
      try {
        setLoading(true);
        const statusKey = activeTab === Status.INVITED ? Status.INVITED : Status.ACCEPTED;
        const data = await fetchInvitations(statusKey);
        setInvitations(data);
      } catch (error) {
        toast({
          title: "Erro ao carregar convites",
          description: "Não foi possível carregar os convites. Tente novamente mais tarde.",
          variant: "destructive",
        });
      } finally {
        setLoading(false);
      }
    };

    loadInvitations();
  }, [activeTab,toast]);

    return (
      <div className="max-w-4xl mx-auto p-4">
        <div className="bg-white rounded-lg shadow-lg overflow-hidden">
          <TabNavigation activeTab={activeTab} setActiveTab={setActiveTab} />
          <InvitationList invitations={invitations} onInvitationAction={handleInvitationAction}/>
        </div>
      </div>
    );
};