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
            WriteLine($"TaskId={Thread.CurrentThread.ManagedThreadId} {message}");
        }

        private void WhereIAmBefore(string message)
            => WhereIAm($"Before {message}");

        private void WhereIAmAfter(string message)
            => WhereIAm($"After {message}");


        private async Task<string> WaitAAsync()
        {
            var methode = nameof(WaitAAsync);
            WhereIAmBefore(methode);
            await Task.Delay(1);
            var x= DateTime.Now.ToShortTimeString();
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
            await WaitBAsync();
            var x = DateTime.Now.ToShortTimeString();
            WhereIAmAfter(methode);
            return x;
        }
        private async Task<string> WaitBBBAsync()
        {
            var methode = $"{nameof(WaitBBBAsync)} ConfigureAwait(false)";
            WhereIAmBefore(methode);
            await WaitBBAsync();
            var x = DateTime.Now.ToShortTimeString();
            WhereIAmAfter(methode);
            return x;
        }
        private async Task<string> WaitBBBBAsync()
        {
            var methode = $"{nameof(WaitBBBBAsync)} ConfigureAwait(false)";
            WhereIAmBefore(methode);
            await WaitBBBAsync();
            var x = DateTime.Now.ToShortTimeString();
            WhereIAmAfter(methode);
            return x;
        }

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

        private async Task<string> WaitDAsync()
        {
            var methode = $"{nameof(WaitDAsync)} O=ConfigureAwait(false) ";
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

        private async Task<string> WaitEAsync()
        {
            var methode = $"{nameof(WaitEAsync)} O-ConfigureAwait(false) I-ConfigureAwait(false)";
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

        private async Task<string> WaitFAsync()
        {
            var methode = $"{nameof(WaitFAsync)} I-ConfigureAwait(false)";
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

        [Fact]
        public async Task WhoIsWhoA()
        {
            var methode = nameof(WhoIsWhoA);
            WhereIAmBefore(methode);
            await WaitAAsync();
            WhereIAmAfter(methode);
        }

        [Fact]
        public async Task WhoIsWhoAAAA()
        {
            var methode = nameof(WhoIsWhoAAAA);
            WhereIAmBefore(methode);
            await WaitAAAAAsync();
            WhereIAmAfter(methode);
        }

        [Fact]
        public async Task WhoIsWhoB()
        {
            var methode = nameof(WhoIsWhoB);
            WhereIAmBefore(methode);
            await WaitBAsync();
            WhereIAmAfter(methode);
        }

        [Fact]
        public async Task WhoIsWhoBBBB()
        {
            var methode = nameof(WhoIsWhoBBBB);
            WhereIAmBefore(methode);
            await WaitBBBBAsync();
            WhereIAmAfter(methode);
        }

        [Fact]
        public async Task WhoIsWhoC()
        {
            var methode = nameof(WhoIsWhoC);
            WhereIAmBefore(methode);
            await WaitCAsync();
            WhereIAmAfter(methode);
        }

        [Fact]
        public async Task WhoIsWhoD()
        {
            var methode = nameof(WhoIsWhoD);
            WhereIAmBefore(methode);
            await WaitDAsync();
            WhereIAmAfter(methode);
        }
        [Fact]
        public async Task WhoIsWhoE()
        {
            var methode = nameof(WhoIsWhoE);
            WhereIAmBefore(methode);
            await WaitDAsync();
            WhereIAmAfter(methode);
        }

        [Fact]
        public async Task WhoIsWhoF()
        {
            var methode = nameof(WhoIsWhoF);
            WhereIAmBefore(methode);
            await WaitDAsync();
            WhereIAmAfter(methode);
        }





    }



}
