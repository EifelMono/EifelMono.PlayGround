using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using EifelMono.PlayGround.TestObjects;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XLinq
{
    public class XAnyCount : XPlayGround
    {
        public XAnyCount(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void CompareAnyCount()
        {
            int Runs = 10;
            foreach (var customerCount in new List<int> { 10, 100, 1000, 10000, 100000})
            {
                WriteLine($"Customers={customerCount}");
                var customers = Enumerable.Range(0, customerCount)
                                .Select(i => new Customer {
                                    CustomerId = i,
                                    CustomerName = $"Customer {DateTime.UtcNow} {Guid.NewGuid()} "
                                });
                {
                    WriteLine($"  customers.Count(); Runs={Runs}");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int run = 0; run < Runs; run++)
                        customers.Count();
                    stopwatch.Stop();
                    var time = (double)stopwatch.ElapsedMilliseconds / Runs;
                    WriteLine($"  Meassured={time:0.00} msec ");
                }

                {
                    WriteLine($"  customers.Ayn(); Runs={Runs}");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int run = 0; run < Runs; run++)
                        customers.Any();
                    stopwatch.Stop();
                    var time = (double)stopwatch.ElapsedMilliseconds / Runs;
                    WriteLine($"  Meassured={time:0.00} msec ");
                }
            }
        }
    }
}
