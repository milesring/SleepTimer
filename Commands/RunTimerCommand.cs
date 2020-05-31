using SleepTimer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SleepTimer.Commands
{
    public class RunTimerCommand : BaseCommand
    {
        override
        public bool CanExecute(object parameter)
        {
            var timer = parameter as TimerObject;
            if (timer.TimerRunning || timer.TimerLength == TimeSpan.Zero)
            {
                return false;
            }
            return true;
        }

        override
        public void Execute(object parameter)
        {
            var timer = parameter as TimerObject;
            timer.SetTimer();
            timer.StartTimer();
        }
    }
}
