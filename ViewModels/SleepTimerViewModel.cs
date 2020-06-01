using SleepTimer.Commands;
using SleepTimer.Models;
using System;

namespace SleepTimer.ViewModels
{
    public class SleepTimerViewModel : BaseViewModel
    {
        #region Local Fields
        private TimerObject timerObject;
        private RunTimerCommand runTimerCommand;
        private StopTimerCommand stopTimerCommand;
        private ResetTimerCommand resetTimerCommand;
        private int days, hours, minutes, seconds;

        #endregion
        public SleepTimerViewModel()
        {

        }

        #region Properties
        public TimerObject TimerObject
        {
            get { 
                if(timerObject == null)
                {
                    timerObject = new TimerObject();
                }
                return timerObject;
            }
            set
            {
                timerObject = value;
                OnPropertyChanged(nameof(TimerObject));
            }
        }
        public int Days
        {
            get { return days; }
            set { 
                days = value;
                OnPropertyChanged(nameof(Days));
                ValidateTime();
            }
        }
        public int Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                OnPropertyChanged(nameof(Hours));
                ValidateTime();
            }
        }
        public int Minutes
        {
            get { return minutes; }
            set
            {
                minutes = value;
                OnPropertyChanged(nameof(Minutes));
                ValidateTime();
            }
        }
        public int Seconds
        {
            get { return seconds; }
            set
            {
                seconds = value;
                OnPropertyChanged(nameof(Seconds));
                ValidateTime();
            }
        }


        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        void ValidateTime()
        {
            var time = new TimeSpan(Days, Hours, Minutes, Seconds);
            TimerObject.TimerLength = time;
        }
        #endregion

        #region Commands
        public RunTimerCommand RunTimerCommand
        {
            get
            {
                if(runTimerCommand == null)
                {
                    runTimerCommand = new RunTimerCommand();
                }
                return runTimerCommand;
            }
            set
            {
                runTimerCommand = value;
                OnPropertyChanged(nameof(RunTimerCommand));
            }
        }

        public StopTimerCommand StopTimerCommand
        {
            get
            {
                if(stopTimerCommand == null)
                {
                    stopTimerCommand = new StopTimerCommand();
                }
                return stopTimerCommand;
            }
            set
            {
                stopTimerCommand = value;
                OnPropertyChanged(nameof(StopTimerCommand));
            }
        }

        public ResetTimerCommand ResetTimerCommand
        {
            get
            {
                if(resetTimerCommand == null)
                {
                    resetTimerCommand = new ResetTimerCommand();
                }
                return resetTimerCommand;
            }
            set
            {
                resetTimerCommand = value;
                OnPropertyChanged(nameof(ResetTimerCommand));
            }
        }
        #endregion


    }
}
