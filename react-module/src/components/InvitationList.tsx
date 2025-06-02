
import InvitationCard from './InvitationCard';
import { Invitation } from '../types/invitation';

interface InvitationListProps {
  invitations: Invitation[]
  onInvitationAction:(id:string) => void
}

const InvitationList = ({ invitations, onInvitationAction }: InvitationListProps) => {
  if (invitations.length === 0) {
    return (
      <div className="p-8 text-center text-gray-500">
        <p className="text-lg">Nenhum convite encontrado</p>
      </div>
    );
  }

  return (
    <div className="divide-y divide-gray-100">
      {invitations.map((invitation) => (
        <InvitationCard key={invitation.jobId} invitation={invitation} onInvitationAction={onInvitationAction} />
      ))}
    </div>
  );
};

export default InvitationList;
