using System;
using System.Collections.Generic;
using System.Text;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XOthers
{
    public class XDateTime : XPlayGround
    {
        public XDateTime(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void Test1()
        {
            var dateTime = DateTime.MinValue;

            if (!DateTime.TryParse("xxx", out dateTime))
                Output.WriteLine("Wrong DateTime");
            else
                Output.WriteLine("DateTime Ok");
            Output.WriteLine($"DateTime={dateTime}");
        }

        [Fact]
        public void Test2()
        {
            if (!DateTime.TryParse("xxx", out var dateTime))
                Output.WriteLine("Wrong DateTime");
            else
                Output.WriteLine("DateTime Ok");
            Output.WriteLine($"DateTime={dateTime}");
        }

        [Fact]
        public void Test3()
        {
            if (!DateTime.TryParse("2019.01.01", out var dateTime))
                Output.WriteLine("Wrong DateTime");
            else
                Output.WriteLine("DateTime Ok");
            Output.WriteLine($"DateTime={dateTime}");
        }

        [Fact]
        public void Test4()
        {
            if (!ToInt("test", out var dateTime))
                Output.WriteLine("Wrong DateTime");
            else
                Output.WriteLine("DateTime Ok");
            Output.WriteLine($"DateTime={dateTime}");
        }

        private bool ToInt(string test, out int value)
        {
            value= 0;
            return true;
        }
    }
}
