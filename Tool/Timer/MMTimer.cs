using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tool.Timer
{
    public class MMTimer : IDisposable
    {
        public delegate void TimerCallback(uint uTimerID, uint uMsg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2);

        [DllImport("Winmm.dll", CharSet = CharSet.Auto)]
        private static extern uint timeSetEvent(uint uDelay, uint uResolution, TimerCallback lpTimeProc, UIntPtr dwUser,
                                        uint fuEvent);
        [DllImport("Winmm.dll", CharSet = CharSet.Auto)]
        private static extern uint timeKillEvent(uint uTimerID);

        [DllImport("Winmm.dll", CharSet = CharSet.Auto)]
        private static extern uint timeGetTime();

        [DllImport("Winmm.dll", CharSet = CharSet.Auto)]
        private static extern uint timeBeginPeriod(uint uPeriod);

        [DllImport("Winmm.dll", CharSet = CharSet.Auto)]
        private static extern uint timeEndPeriod(uint uPeriod);
        [Flags]
        public enum fuEvent : uint
        {
            TIME_ONESHOT = 0, //Event occurs once, after uDelay milliseconds. 
            TIME_PERIODIC = 1,
            TIME_CALLBACK_FUNCTION = 0x0000, /* callback is function */
            TIME_CALLBACK_EVENT_SET = 0x0010, /* callback is event - use SetEvent */
            TIME_CALLBACK_EVENT_PULSE = 0x0020  /* callback is event - use PulseEvent */
        }
        private int interval = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cbFunc"></param>
        public MMTimer(TimerCallback cbFunc)
        {
            this.thisCB = cbFunc;
        }

        public MMTimer(Action getHttpStatus)
        {
            this.getHttpStatus = getHttpStatus;
        }

        /// <summary>
        /// The current timer instance ID
        /// </summary>
        private uint id = 0;

        /// <summary>
        /// callback function
        /// </summary>
        TimerCallback thisCB = null;

        //IDisposable code
        private bool disposed = false;
        private Action getHttpStatus;

        /// <summary>
        /// 触发间隔ms
        /// </summary>
        public int Interval
        {
            get
            {
                return interval;
            }

            set
            {
                interval = value;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Stop();
                }
            }
            disposed = true;
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~MMTimer()
        {
            Dispose(false);
        }

        /// <summary>
        /// 停止定时器
        /// </summary>
        public void Stop()
        {
            lock (this)
            {
                if (id != 0)
                {
                    timeKillEvent(id);
                    id = 0;
                }
            }
        }
        /// <summary>
        /// 开启定时器
        /// </summary>
        /// <param name="ms">Timer interval in milliseconds</param>
        /// <param name="repeat">If true sets a repetitive event, otherwise sets a one-shot</param>
        public void Start(int ms, bool repeat)
        {
            Stop();
            GC.KeepAlive(thisCB);

            //Set the timer type flags
            fuEvent f = fuEvent.TIME_CALLBACK_FUNCTION | (repeat ? fuEvent.TIME_PERIODIC : fuEvent.TIME_ONESHOT);

            lock (this)
            {
                id = timeSetEvent(uint.Parse(ms.ToString()), 0, thisCB, UIntPtr.Zero, (uint)f);
                if (id == 0)
                {
                    throw new Exception("timeSetEvent error");
                }
            }
        }
        /// <summary>
        /// 开启定时器
        /// </summary>
        /// <param name="repeat">If true sets a repetitive event, otherwise sets a one-shot</param>
        public void Start(bool repeat)
        {
            Stop();
            GC.KeepAlive(thisCB);

            //Set the timer type flags
            fuEvent f = fuEvent.TIME_CALLBACK_FUNCTION | (repeat ? fuEvent.TIME_PERIODIC : fuEvent.TIME_ONESHOT);

            lock (this)
            {
                id = timeSetEvent(uint.Parse((Interval).ToString()), 0, thisCB, UIntPtr.Zero, (uint)f);
                if (id == 0)
                {
                    throw new Exception("timeSetEvent error");
                }
            }
        }
    }
}
