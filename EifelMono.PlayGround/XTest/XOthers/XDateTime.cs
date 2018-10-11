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

        // Out need to initialize the value in the method
        private bool ToInt(string test, out int value)
        {
            value = 0;
            return true;
        }

        [Fact]
        public void DateTimeCompare()
        {
            {
                var d1 = new DateTime(1961, 2, 14, 11, 12, 13, 15);
                var d2 = new DateTime(1961, 2, 14, 11, 12, 13, 16);

                Assert.NotEqual(d1, d2);
                Assert.False(IsEqualTo(d1, d2));
            }
            {
                var d1 = new DateTime(1961, 2, 14, 11, 12, 13, 15);
                var d2 = new DateTime(1961, 2, 14, 11, 12, 13, 15);

                Assert.Equal(d1, d2);
                Assert.True(IsEqualTo(d1, d2));
            }
            {
                var d1 = new DateTime(1961, 2, 14, 11, 12, 13, 15, DateTimeKind.Local);
                var d2 = new DateTime(1961, 2, 14, 11, 12, 13, 15, DateTimeKind.Utc);

                Assert.Equal(d1, d2);
                Assert.True(IsEqualTo(d1, d2));
            }
            {
                var d1 = new DateTime(1961, 2, 14, 11, 12, 13, 15, DateTimeKind.Unspecified);
                var d2 = new DateTime(1961, 2, 14, 11, 12, 13, 15, DateTimeKind.Utc);

                Assert.Equal(d1, d2);
                Assert.True(IsEqualTo(d1, d2));
            }
        }


        private bool IsEqualTo(DateTime instance, DateTime compareValue)
        {
            if (instance == compareValue)
                return true;

            return (
                (instance.Year == compareValue.Year) &&
                (instance.Month == compareValue.Month) &&
                (instance.Day == compareValue.Day) &&
                (instance.Hour == compareValue.Hour) &&
                (instance.Minute == compareValue.Minute) &&
                (instance.Second == compareValue.Second) &&
                (instance.Millisecond == compareValue.Millisecond));
        }
    }
}
