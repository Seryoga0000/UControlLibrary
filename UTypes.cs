using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UControlLibrary
{
    public class UTypes
    {
        public struct TimerInt
        {
            public int CInt { get; private set; }
            public int Limit { get; private set; }
            public void ToZero()
            {
                CInt = 0;
            }

            public static implicit operator int(TimerInt cycleInt)
            {
                return cycleInt.CInt;
            }

            public TimerInt Increment(int incr)
            {
                var cycleIntGlobalIteration = CInt + incr;
                if (cycleIntGlobalIteration >= Limit) CInt = 0;
                CInt = cycleIntGlobalIteration;
                return this;
            }

            public static bool operator ==(TimerInt cycleInt, int a)
            {
                return cycleInt.CInt == a;
            }
            public static TimerInt operator +(TimerInt cycleInt, int a)
            {
                return new TimerInt(cycleInt.CInt + a, cycleInt.Limit); ;
            }
            public static bool operator !=(TimerInt cycleInt, int a)
            {
                return !(cycleInt == a);
            }

            public override string ToString()
            {
                return CInt.ToString();
            }

            public TimerInt(int cInt,int lim)
            {
                CInt = cInt;
                Limit = lim;
            }
        }
    }
}
