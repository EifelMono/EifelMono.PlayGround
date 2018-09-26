using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XTiming
{
    public class XSleepDelayAwait : XPlayGround
    {
        public XSleepDelayAwait(ITestOutputHelper output) : base(output) { }

        private const int Runs = 10;
        private List<int> WaitValues { get; } = new List<int> { 1, 5, 10, 15, 20, 25, 50, 100, 200, 1000 };
        [Fact]
        public void XThreadSleep()
            => XThreadSleepX(WaitValues);
        private void XThreadSleepX(List<int> waitValues)
        {
            foreach (var waitValue in waitValues ?? WaitValues)
            {
                Line();
                WriteLine($"Thread.Sleep({waitValue}) msec Runs={Runs}");
                var stopwatch = Stopwatch.StartNew();
                for (var run = 0; run < Runs; run++)
                    Thread.Sleep(waitValue);
                stopwatch.Stop();
                var time = (double)stopwatch.ElapsedMilliseconds / Runs;
                WriteLine($"Meassured={time:0.00} msec loss={time - waitValue:0.00} ms");
                Line();
            }
        }

        [Fact]
        public async void XAsyncTaskDelay()
            => await XAsyncTaskDelayX(WaitValues);

        private async Task XAsyncTaskDelayX(List<int> waitValues)
        {
            foreach (var waitValue in waitValues ?? WaitValues)
            {
                {
                    Line();
                    WriteLine($"await Task.Delay({waitValue}) msec Runs={Runs}");
                    var stopwatch = Stopwatch.StartNew();
                    for (var run = 0; run < Runs; run++)
                        await Task.Delay(waitValue);
                    stopwatch.Stop();
                    var time = (double)stopwatch.ElapsedMilliseconds / Runs;
                    WriteLine($"Meassured={time:0.00} msec loss={time - waitValue:0.00} ms");
                    Line();
                }
            }
        }

        [Fact]
        public async void XAsyncTaskDelayConfigureAWait()
            => await XAsyncTaskDelayConfigureAWaitX(WaitValues);
        private async Task XAsyncTaskDelayConfigureAWaitX(List<int> waitValues)
        {
            foreach (var waitValue in waitValues ?? WaitValues)
            {
                Line();
                WriteLine($"await Task.Delay({waitValue}).ConfigureAwait(false) msec Runs={Runs}");
                var stopwatch = Stopwatch.StartNew();
                for (var run = 0; run < Runs; run++)
                    await Task.Delay(waitValue).ConfigureAwait(false);
                stopwatch.Stop();
                var time = (double)stopwatch.ElapsedMilliseconds / Runs;
                WriteLine($"Meassured={time:0.00} msec loss={time - waitValue:0.00} ms");
                Line();
            }
        }

        [Fact]
        public void XTaskDelayWait()
            => XTaskDelayWaitX(WaitValues);

        private void XTaskDelayWaitX(List<int> waitValues)
        {
            foreach (var waitValue in waitValues ?? WaitValues)
            {
                Line();
                WriteLine($"Task.Delay({waitValue}).Wait() msec Runs={Runs}");
                var stopwatch = Stopwatch.StartNew();
                for (var run = 0; run < Runs; run++)
                    Task.Delay(waitValue).Wait();
                stopwatch.Stop();
                var time = (double)stopwatch.ElapsedMilliseconds / Runs;
                WriteLine($"Meassured={time:0.00} msec loss={time - waitValue:0.00} ms");
                Line();
            }
        }

        [Fact]
        public void XAll_1_5_10_15()
        {
            XAllX(new List<int> { 1, 5, 10, 15 });
        }
        [Fact]
        public void XAll_20_25_50_75()
        {
            XAllX(new List<int> { 20, 25, 50, 75 });
        }
        [Fact]
        public void XAll_100_500()
        {
            XAllX(new List<int> { 100, 500});
        }

        [Fact]
        public void XAll_1000_5000()
        {
            XAllX(new List<int> { 1000, 5000 });
        }

        [Fact]
        public void XAll_1_10_100_1000()
        {
            XAllX(new List<int> { 1, 10, 100, 1000 });
        }

        private async void XAllX(List<int> waitValues)
        {
            foreach (var waitValue in waitValues)
            {
                Line();
                WriteLine($"wait={waitValue} ms");
                XThreadSleepX((new List<int> { waitValue }));
                XTaskDelayWaitX((new List<int> { waitValue }));
                await XAsyncTaskDelayX((new List<int> { waitValue }));
                await XAsyncTaskDelayConfigureAWaitX((new List<int> { waitValue }));
              
            }
        }
    }
}
