
import { Status } from '@/types/invitation';
import React from 'react';

interface TabNavigationProps {
  activeTab: number;
  setActiveTab: (tab: Status) => void;
}

const TabNavigation = ({ activeTab, setActiveTab }: TabNavigationProps) => {
  return (
    <div className="flex border-b border-gray-200">
      <button
        onClick={() => setActiveTab(Status.INVITED)}
        className={`flex-1 py-4 px-6 text-center font-medium transition-all duration-300 ${
          activeTab === Status.INVITED
            ? 'text-orange-600 border-b-2 border-orange-500 bg-orange-50'
            : 'text-gray-500 hover:text-gray-700 hover:bg-gray-50'
        }`}
      >
        Invited
      </button>
      <button
        onClick={() => setActiveTab(Status.ACCEPTED)}
        className={`flex-1 py-4 px-6 text-center font-medium transition-all duration-300 ${
          activeTab === Status.ACCEPTED
            ? 'text-orange-600 border-b-2 border-orange-500 bg-orange-50'
            : 'text-gray-500 hover:text-gray-700 hover:bg-gray-50'
        }`}
      >
        Accepted
      </button>
    </div>
  );
};

export default TabNavigation;
