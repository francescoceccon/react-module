import { MapPin, Briefcase, Phone, Mail } from 'lucide-react';
import ActionButtons from './ActionButtons';
import UserAvatar from './UserAvatar';
import { Invitation, Status } from '../types/invitation';
import { format } from 'date-fns';

interface InvitationCardProps {
  invitation: Invitation;
  onInvitationAction: (id: string) => void;
}

const InvitationCard = ({ invitation, onInvitationAction }: InvitationCardProps) => {
  const isAccepted = invitation.status === Status.ACCEPTED;

  return (
    <div className="p-6 border-b last:border-none bg-white">
      <div className="flex items-start space-x-4">
        <UserAvatar name={invitation.firstName} />

        <div className="flex-1 min-w-0">
          <div className="flex items-center justify-between mb-2">
            <h3 className="text-base font-semibold text-gray-900">
              {invitation.firstName}
            </h3>
            <span className="text-sm text-gray-500">
               {format(new Date(invitation.createdAt), "MMMM d yyyy '@' h:mm a")}
            </span>
          </div>

          <div className="flex flex-wrap items-center space-x-4 mb-2 text-gray-600 text-sm">
            <div className="flex items-center space-x-1">
              <MapPin size={16} />
              <span>{invitation.suburb}</span>
            </div>
            <div className="flex items-center space-x-1">
              <Briefcase size={16} />
              <span>{invitation.category}</span>
            </div>
            <span>Job ID: {invitation.jobId}</span>
            {isAccepted && (<span>${invitation.price.toFixed(2)}</span>)}  
          </div>

          {isAccepted && (
            <div className="flex flex-col gap-1 mb-2 text-sm text-orange-600">
              {(invitation.phone || invitation.email) &&(
                <div className="flex items-center gap-3">
                  <Phone size={16}  className='text-black'/>
                  <span>{invitation.phone}</span>
                  <Mail size={16} className='text-black'/>
                  <span>{invitation.email == null || invitation.email == '' ? '' : invitation.email} </span>
                </div>
                
              )}
            </div>
          )}

          <p className="text-gray-700 text-sm mb-4">{invitation.description}</p>

          <div className="flex items-center justify-between">
            <ActionButtons 
              status={invitation.status}
              amount={invitation.price}
              id={invitation.id}
              onAction={() => onInvitationAction(invitation.id)}
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default InvitationCard;
