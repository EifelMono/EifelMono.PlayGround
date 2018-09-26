using System;
using System.Collections.Generic;
using System.Text;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XPatternMatching
{
    public class XSwitch : XPlayGround
    {
        public XSwitch(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestNull()
        {
            //switch (o)
            //{
            //    case null:
            //        Console.WriteLine("it's a constant pattern");
            //        break;
            //    case int i:
            //        Console.WriteLine("it's an int");
            //        break;
            //    case Person p when p.FirstName.StartsWith("Ka"):
            //        Console.WriteLine($"a Ka person {p.FirstName}");
            //        break;
            //    case Person p:
            //        Console.WriteLine($"any other person {p.FirstName}");
            //        break;
            //    case var x:
            //        Console.WriteLine($"it's a var pattern with the type {x?.GetType().Name} ");
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
