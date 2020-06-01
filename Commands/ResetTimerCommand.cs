using SleepTimer.Models;
using System;

namespace SleepTimer.Commands
{
    public class ResetTimerCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            var timer = parameter as TimerObject;
            if(!timer.TimerRunning 
                && timer.RemainingTime != timer.TimerLength 
                && timer.RemainingTime > TimeSpan.Zero)
            {
                return true;
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            var timer = parameter as TimerObject;
            timer.ResetTimer();
        }
    }
}
