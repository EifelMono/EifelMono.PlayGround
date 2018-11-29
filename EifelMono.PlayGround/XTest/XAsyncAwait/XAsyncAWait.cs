using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XAsyncAwait
{
    public class XAsyncAWait : XPlayGround
    {
        public XAsyncAWait(ITestOutputHelper output) : base(output)
        {
        }

        private void WhereIAm(string message)
        {
            WriteLine($"{DateTime.Now.ToString("HH:mm:ss,fff")} TaskId={Task.CurrentId} ThreadId={Thread.CurrentThread.ManagedThreadId} {message}");
        }

        private void WhereIAmBefore(string message, bool split = false)
        {
            if (split)
                WriteLine(new string('-', 40));
            WhereIAm($"Before {message}");
        }

        private void WhereIAmAfter(string message)
            => WhereIAm($"After {message}");

        #region A
        private async Task<string> WaitAAsync()
        {
            var methode = nameof(WaitAAsync);
            WhereIAmBefore(methode);
            await Task.Delay(1);
            var x = DateTime.Now.ToShortTimeString();
            WhereIAmAfter(methode);
            return x;
        }

        private async Task<string> WaitAAAsync()
        {
            var methode = nameof(WaitAAAsync);
            WhereIAmBefore(methode);
            var x = await WaitAAsync();
            WhereIAmAfter(methode);
            return x;
        }

        private async Task<string> WaitAAAAsync()
        {
            var methode = nameof(WaitAAAAsync);
            WhereIAmBefore(methode);
            var x = await WaitAAAsync();
            WhereIAmAfter(methode);
            return x;
        }

        private async Task<string> WaitAAAAAsync()
        {
            var methode = nameof(WaitAAAAAsync);
            WhereIAmBefore(methode);
            var x = await WaitAAAAsync();
            WhereIAmAfter(methode);
            return x;
        }
        #endregion

        #region B
        private async Task<string> WaitBAsync()
        {
            var methode = $"{nameof(WaitBAsync)} ConfigureAwait(false)";
            WhereIAmBefore(methode);
            await Task.Delay(1).ConfigureAwait(false);
            var x = DateTime.Now.ToShortTimeString();
            WhereIAmAfter(methode);
            return x;
        }

        private async Task<string> WaitBBAsync()
        {
            var methode = $"{nameof(WaitBBAsync)} ConfigureAwait(false)";
            WhereIAmBefore(methode);
            await WaitBAsync().ConfigureAwait(false);
            var x = DateTime.Now.ToShortTimeString();
            WhereIAmAfter(methode);
            return x;
        }
        private async Task<string> WaitBBBAsync()
        {
            var methode = $"{nameof(WaitBBBAsync)} ConfigureAwait(false)";
            WhereIAmBefore(methode);
            await WaitBBAsync().ConfigureAwait(false);
            var x = DateTime.Now.ToShortTimeString();
            WhereIAmAfter(methode);
            return x;
        }
        private async Task<string> WaitBBBBAsync()
        {
            var methode = $"{nameof(WaitBBBBAsync)} ConfigureAwait(false)";
            WhereIAmBefore(methode);
            await WaitBBBAsync().ConfigureAwait(false);
            var x = DateTime.Now.ToShortTimeString();
            WhereIAmAfter(methode);
            return x;
        }
        #endregion

        #region C
        private async Task<string> WaitCAsync()
        {
            var methode = nameof(WaitCAsync);
            WhereIAmBefore(methode);
            var x = await Task.Run(async () =>
            {
                WhereIAmBefore($"{methode} TaskRunInside");
                await Task.Delay(1);
                var y = DateTime.Now.ToShortTimeString();
                WhereIAmAfter($"{methode} TaskRunInside");
                return y;
            });
            WhereIAmAfter(methode);
            return x;
        }
        private async Task<string> WaitCCAsync()
        {
            var methode = $"{nameof(WaitCCAsync)} O=ConfigureAwait(false) ";
            WhereIAmBefore(methode);
            var x = await Task.Run(async () =>
            {
                WhereIAmBefore($"{methode} TaskRunInside");
                await Task.Delay(1);
                var y = DateTime.Now.ToShortTimeString();
                WhereIAmAfter($"{methode} TaskRunInside");
                return y;
            }).ConfigureAwait(false);
            WhereIAmAfter(methode);
            return x;
        }

        private async Task<string> WaitCCCAsync()
        {
            var methode = $"{nameof(WaitCCCAsync)} O-ConfigureAwait(false) I-ConfigureAwait(false)";
            WhereIAmBefore(methode);
            var x = await Task.Run(async () =>
            {
                WhereIAmBefore($"{methode} TaskRunInside");
                await Task.Delay(1).ConfigureAwait(false);
                var y = DateTime.Now.ToShortTimeString();
                WhereIAmAfter($"{methode} TaskRunInside");
                return y;
            }).ConfigureAwait(false);
            WhereIAmAfter(methode);
            return x;
        }
        private async Task<string> WaitCCCCAsync()
        {
            var methode = $"{nameof(WaitCCAsync)} I-ConfigureAwait(false)";
            WhereIAmBefore(methode);
            var x = await Task.Run(async () =>
            {
                WhereIAmBefore($"{methode} TaskRunInside");
                await Task.Delay(1).ConfigureAwait(false);
                var y = DateTime.Now.ToShortTimeString();
                WhereIAmAfter($"{methode} TaskRunInside");
                return y;
            });
            WhereIAmAfter(methode);
            return x;
        }
        #endregion

        [Fact]
        public async Task WhoIsWhoA()
        {
            var methode = nameof(WhoIsWhoA);
            WhereIAmBefore(methode, true);
            await WaitAAsync();
            WhereIAmAfter(methode);

            WhereIAmBefore(methode, true);
            await WaitAAAAAsync();
            WhereIAmAfter(methode);
        }

        [Fact]
        public async Task WhoIsWhoB()
        {
            var methode = nameof(WhoIsWhoB);
            WhereIAmBefore(methode, true);
            await WaitBAsync();
            WhereIAmAfter(methode);

            methode = nameof(WhoIsWhoB);
            WhereIAmBefore(methode, true);
            await WaitBBBBAsync();
            WhereIAmAfter(methode);
        }

        [Fact]
        public async Task WhoIsWhoC()
        {
            var methode = nameof(WhoIsWhoC);
            WhereIAmBefore(methode, true);
            await WaitCAsync();
            WhereIAmAfter(methode);

            WhereIAmBefore(methode, true);
            await WaitCCAsync();
            WhereIAmAfter(methode);

            WhereIAmBefore(methode, true);
            await WaitCCCAsync();
            WhereIAmAfter(methode);

            WhereIAmBefore(methode, true);
            await WaitCCCCAsync();
            WhereIAmAfter(methode);
        }

        [Fact]
        public async Task TestIt()
        {
            async Task<int> DoDelay()
            {
                WhereIAmBefore("DoDelay");
                await Task.Delay(100);
                WhereIAmAfter("DoDelay");
                return 1;
            }

            async Task<T> CallAction<T>(Func<Task<T>> func) 
            {
                WhereIAmBefore("CallAction");
                var x = await func().ConfigureAwait(false);
                WriteLine($"x={x}");
                WhereIAmAfter("CallAction");
                return x;
            }

            WhereIAmBefore("TestIt1", true);
            var y = await CallAction(() => DoDelay()).ConfigureAwait(false);
            WriteLine($"y={y}");
            WhereIAmAfter("TestIt1");

            WhereIAmBefore("TestIt2", true);
            var z = await await DoDelay().ConfigureAwait(false);
            WriteLine($"y={z}");
            WhereIAmAfter("TestIt2");
        }
    }
}
