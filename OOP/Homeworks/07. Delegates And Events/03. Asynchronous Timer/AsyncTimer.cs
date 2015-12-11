namespace _03.Asynchronous_Timer
{
    using System;
    using System.Threading;

    public class AsyncTimer
    {
        public event Action OnTick;

        public Thread thread;

        public AsyncTimer(Action action, int ticks, int interval)
        {
            this.Action = action;
            this.Ticks = ticks;
            this.Interval = interval;
            this.OnTick += this.Action;
            this.CreateThread();
        }

        public Action Action { get; set; }

        public int Ticks { get; set; }

        public int Interval { get; set; }

        private void CreateThread()
        {
            this.thread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                for (int i = 0; i < this.Ticks; i++)
                {
                    Thread.Sleep(this.Interval);
                    this.OnTick();
                }
            });
        }

        public void Run()
        {
            this.thread.Start();
        }
    }
}
