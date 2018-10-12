using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using EifelMono.PlayGround.XCore;
using EifelMono.PlayGround.XTest.XLinq;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XOthers
{
    public class XStopwatch : XPlayGround
    {
        public XStopwatch(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void Test1()
        {
            foreach (var delay in LinqNew.Params(1, 10, 50, 100, 200, 500, 1000, 2000))
            {
                WriteLine($"Stopwatch test Delay({delay})");
                var stopwatch = Stopwatch.StartNew();
                Thread.Sleep(delay);
                stopwatch.Stop();

                WriteLine($"stopwatch.ElapsedMilliseconds={stopwatch.ElapsedMilliseconds}");
                WriteLine($"stopwatch.ElapsedSeconds={stopwatch.ElappsedSeconds()}");
            }
        }
    }
}
