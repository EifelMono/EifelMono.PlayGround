using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EifelMono.PlayGround.XTest.XOthers
{
    public static class OthersExtensions
    {
        public static long ElappsedSeconds(this Stopwatch stopwatch)
            => stopwatch.ElapsedMilliseconds / 1000;
    }
}
