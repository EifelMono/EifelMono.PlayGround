using System;
using System.Collections.Generic;
using System.Text;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XCast
{
    public class XClassCasts : XPlayGround
    {
        public XClassCasts(ITestOutputHelper output) : base(output)
        {
        }

        public class ClassA { }

        public class ClassA<T> : ClassA { }

        public class ClassAString : ClassA<string> { }

        [Fact]
        public void Casts()
        {
            var VA = new ClassA();
            var VB = new ClassA<string>();
            var VC = new ClassAString();
            var VD = new ClassA<int>();

            VA = VB;
            VA = VC;
            VA = VD;

            // B = (ClassA<string>)A;       // InvalidCastException during run
            VB = VC;
            // B = (ClassA<string>)D;       // Does not compile

            // C = (ClassAString)A;         // InvalidCastException during run
            VC = (ClassAString)VB;
            // C = (ClassAString)D;         // Does not compile

            VD = (ClassA<int>)VA;
            // D = (ClassA<int>)B;          // Does not compile
            // D = (ClassA<int>)C;          // Does not compile
        }

   
    }


  
}
