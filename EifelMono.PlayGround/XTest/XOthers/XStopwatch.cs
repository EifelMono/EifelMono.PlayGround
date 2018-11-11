using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using EifelMono.PlayGround.XCore;
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
            foreach (var delay in 1.Params(1, 10, 50, 100, 200, 500, 1000, 2000))
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

    public static class LinqExtension
    {
        public static IEnumerable<T> Params<T>(this T thisValue, params T[] @params)
            => @params;
        public static IEnumerable<T> Params<T>(this Type thisValue, params T[] @params)
            => @params;
    }
}
