
import React from 'react';

interface UserAvatarProps {
  name: string;
}

const UserAvatar = ({ name }: UserAvatarProps) => {
  const getInitials = (name: string) => {
    return name
      .split(' ')
      .map(word => word[0])
      .join('')
      .toUpperCase()
      .slice(0, 2);
  };

  return (
    <div className="w-12 h-12 bg-orange-500 rounded-full flex items-center justify-center text-white font-semibold text-lg">
      {getInitials(name)}
    </div>
  );
};

export default UserAvatar;
