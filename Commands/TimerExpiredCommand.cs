﻿using System.Runtime.InteropServices;

namespace SleepTimer.Commands
{
    public class TimerExpiredCommand : BaseCommand
    {
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var hibernate = (bool)parameter;
            if (hibernate)
            {
                Hibernate();
            }
            else
            {
                Standby();
            }
            
        }
        
        void Standby()
        {
            // Standby
            SetSuspendState(false, true, true);
        }

        void Hibernate()
        {
            // Hibernate
            SetSuspendState(true, true, true);
        }
    }
}
