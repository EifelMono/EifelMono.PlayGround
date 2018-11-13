using System;
using System.Collections.Generic;
using System.Text;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XCast
{
    public class XTypeThings : XPlayGround
    {
        public XTypeThings(ITestOutputHelper output) : base(output)
        {
        }

        public class ClassA { }

        public class ClassBA : ClassA { }

        public class ClassCA : ClassA { }

        public class ClassDBA : ClassBA { }

        public class ClassT { }

        public class ClassT<T> : ClassT where T : ClassA { }

        public class ClassTA : ClassT<ClassA> { }
        public class ClassTBA : ClassT<ClassBA> { }
        public class ClassTCA : ClassT<ClassCA> { }
        public class ClassTDBA : ClassT<ClassDBA> { }

        [Fact]
        public void Casts()
        {
            var VT = new ClassT();
            var VTA = new ClassTA();
            var VTBA = new ClassTBA();
            var VTCA = new ClassTCA();
            var VTDBA = new ClassTCA();

            VT = VTA;
            VT = VTBA;
            VT = VTCA;
            VT = VTDBA;

            //VTA = (ClassTA) VT;               // InvalidCastException during run
            // VTA = (ClassTA) VTBA;            // Does not compile
            // VTA = (ClassTA) VTCA;            // Does not compile
            // VTA = (ClassTA) VTDBA;           // Does not compile

            // VTBA = (ClassTBA) VT;            // InvalidCastException during run
            // VTBA = (ClassTBA) VTA;           // Does not compile
            // VTBA = (ClassTBA) VTCA;          // Does not compile
            // VTBA = (ClassTBA) VTDBA;         // Does not compile

            // VTCA = (ClassTCA)VT;             // Does not compile
            // VTCA = (ClassTCA)VTA;            // Does not compile
            // VTCA = (ClassTCA)VTBA;           // Does not compile
            VTCA = VTDBA;

            // VTDBA = (ClassTDBA)VT;           // Does not compile      
            // VTDBA = (ClassTDBA)VTA;          // Does not compile
            // VTDBA = (ClassTDBA)VTBA;         // Does not compile
            // VTDBA = (ClassTDBA)VTCA;         // Does not compile


            // public class ClassTA : ClassT<ClassA> { }
            var a = new ClassT<ClassA>();
            var b = new ClassTA();  // ClassT<ClassA>;
            a = b;
        }


        [Fact]
        public void ObjectCasts()
        {
            // public class ClassA { }

            // public class ClassTA : ClassT<ClassA> { }

            {
                var a = new ClassT<ClassA>();
                var b = new ClassTA();     // ClassT<ClassBA>;
                a = b;
            }
            {
                var a = new ClassT<ClassA>();
                var b = new ClassTA();          // ClassT<ClassBA>;
                WriteLine($"a {a.GetType().Name}");
                WriteLine($"b {b.GetType().Name}");

                {
                    a = b;                     
                }
                {
                    // b = (ClassTA)a;                      // InvalidCastException during run
                    object o = a;
                    Convert.ChangeType(o, typeof(ClassTA));
                    var x = (ClassTA)o;                     // InvalidCastException during run
                    WriteLine($"o {o.GetType().Name}");
                    WriteLine($"x {x.GetType().Name}");
                }
            }
        }
    }
}
