using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UControlLibrary
{
    public class UTimer
    {
        private CycleInt iteration = new CycleInt(0);
        private CycleInt globalIteration = new CycleInt(0);
        private Timer iterationTimer = new Timer();
        public bool RunWithoutDelay = false;
        public event EventHandler Tick;

        public UTimer()
        {
            iterationTimer.Tick += IterationTimer_Tick;
        }

        public int Interval
        {
            get => iterationTimer.Interval;
            set => iterationTimer.Interval = value;
        }

        public CycleInt Iteration => iteration;

        public CycleInt GlobalIteration => globalIteration;

        private void IterationTimer_Tick(object sender, EventArgs e)
        {

            if (iteration == 0 && RunWithoutDelay)
            {
                iterationTimer.Interval = intervalForRunWithoutDelayMode;
            }

            iteration++;
            globalIteration++;
            OnTick();
        }

        private int intervalForRunWithoutDelayMode;

        public void Start()
        {
            iteration.ToZero();
            if (RunWithoutDelay)
            {
                intervalForRunWithoutDelayMode = iterationTimer.Interval;
                iterationTimer.Interval = 100;
            }

            iterationTimer.Start();
        }

        protected virtual void OnTick()
        {
            Tick?.Invoke(this, EventArgs.Empty);
        }

        public void Stop()
        {
            iterationTimer.Stop();
        }
    }

    public struct CycleInt
    {
        public int CInt { get; private set; }

        public void ToZero()
        {
            CInt = 0;
        }

        public static implicit operator int(CycleInt cycleInt)
        {
            return cycleInt.CInt;
        }

        public static CycleInt operator ++(CycleInt cycleInt)
        {
            var cycleIntGlobalIteration = cycleInt.CInt + 1;
            if (cycleIntGlobalIteration == int.MaxValue) cycleIntGlobalIteration = 0;
            return new CycleInt(cycleIntGlobalIteration);
        }

        public static bool operator ==(CycleInt cycleInt, int a)
        {
            return cycleInt.CInt == a;
        }

        public static bool operator !=(CycleInt cycleInt, int a)
        {
            return !(cycleInt == a);
        }

        public override string ToString()
        {
            return CInt.ToString();
        }

        public CycleInt(int cInt)
        {
            CInt = cInt;
        }
    }
}
