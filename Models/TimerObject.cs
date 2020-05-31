using SleepTimer.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace SleepTimer.Models
{
    public class TimerObject : INotifyPropertyChanged
    {
        #region LocalFields
        private string timerName;
        private TimeSpan timerLength;
        private TimeSpan remainingTime;
        private DispatcherTimer timer;
        private bool timerRunning;
        private TimerExpiredCommand timerExpiredCommand;
        private bool hibernate = true;
        #endregion

        #region Properties
        public string TimerName
        {
            get { return timerName; }
            set
            {
                timerName = value;
                OnPropertyChanged(nameof(TimerName));
            }
        }
        public TimeSpan TimerLength
        {
            get { return timerLength; }
            set
            {
                timerLength = value;
                OnPropertyChanged(nameof(TimerLength));
            }
        }
        public TimeSpan RemainingTime
        {
            get { return remainingTime; }
            set
            {
                remainingTime = value;
                OnPropertyChanged(nameof(RemainingTime));
            }
        }
        public bool TimerRunning
        {
            get { return timerRunning; }
            private set {
                timerRunning = value;
                OnPropertyChanged(nameof(TimerRunning));
            }
        }
        public bool Hibernate
        {
            get { return hibernate; }
            set
            {
                hibernate = value;
                OnPropertyChanged(nameof(Hibernate));
            }
        }
        #endregion

        #region Public Methods
        public void StartTimer()
        {
            TimerRunning = true;
            timer.Start();
        }

        public void SetTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            RemainingTime = TimerLength;
        }

        public void PauseTimer()
        {
            TimerRunning = false;
            timer.Stop();
        }

        public void ResetTimer()
        {
            PauseTimer();
            timer.Tick -= timer_Tick;
            timer = null;
            SetTimer();
        }
        #endregion

        #region Events
        private void timer_Tick(object sender, EventArgs e)
        {
            RemainingTime -= timer.Interval;
            if(RemainingTime == TimeSpan.Zero)
            {
                ResetTimer();
                TimerExpiredCommand.Execute(Hibernate);
            }
        }
        #endregion

        #region Commands
        public TimerExpiredCommand TimerExpiredCommand
        {
            get
            {
                if(timerExpiredCommand == null)
                {
                    timerExpiredCommand = new TimerExpiredCommand();
                }
                return timerExpiredCommand;
            }
            set
            {
                timerExpiredCommand = value;
                OnPropertyChanged(nameof(TimerExpiredCommand));
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion

    }
}
