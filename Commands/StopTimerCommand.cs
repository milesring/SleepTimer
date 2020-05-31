using SleepTimer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SleepTimer.Commands
{
    public class StopTimerCommand : BaseCommand
    {
        override
        public bool CanExecute(object parameter)
        {
            var timer = parameter as TimerObject;
            if (!timer.TimerRunning)
            {
                return false;
            }
            return true;
        }

        override
        public void Execute(object parameter)
        {
            var timer = parameter as TimerObject;
            timer.PauseTimer();
        }
    }
}
