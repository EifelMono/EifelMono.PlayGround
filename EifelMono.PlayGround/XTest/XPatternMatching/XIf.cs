using EifelMono.PlayGround.TestObjects;
using EifelMono.PlayGround.XCore;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XPatternMatching
{

    public class XIf: XPlayGround
    {
        public XIf(ITestOutputHelper output): base(output)
        {
        }

        internal void TestRunSimple(object testObject)
        {
            {
                // var !!!
                Output.WriteLine("if (testObject is var shape)");
                if (testObject is var shape)
                    Output.WriteLine("  true");
                else
                    Output.WriteLine("  false");
                if (shape == null)
                    Output.WriteLine("shape=null");
                else
                    Output.WriteLine($"shape.GetType().Name={shape.GetType().Name}");
            }
            {
                Output.WriteLine("if (testObject is Shape shape)");
                if (testObject is Shape shape)
                {
                    Output.WriteLine("  true");
                    Output.WriteLine($"shape.GetType().Name={shape.GetType().Name}");
                }
                else
                    Output.WriteLine("  false");
            }
            {
                Output.WriteLine("if (testObject is Square shape)");
                if (testObject is Square shape)
                    Output.WriteLine("  true");
                else
                    Output.WriteLine("  false");
            }
            {
                Output.WriteLine("if (testObject is Rectangle shape)");
                if (testObject is Rectangle shape)
                    Output.WriteLine("  true");
                else
                    Output.WriteLine("  false");
            }
            {
                Output.WriteLine("if (testObject is Circle shape)");
                if (testObject is Circle shape)
                    Output.WriteLine("  true");
                else
                    Output.WriteLine("  false");
            }
        }
        internal void TestRunShape(object testObject)
        {
            {
                Output.WriteLine("if (testObject is var shape && shape != null)");
                if (testObject is var shape && shape != null)
                    Output.WriteLine("  true");
                else
                    Output.WriteLine("  false");
            }
            {
                Output.WriteLine(" if (testObject is var shape || shape != null)");
                if (testObject is var shape || shape != null)
                    Output.WriteLine("  true");
                else
                    Output.WriteLine("  false");
            }
        }

        internal void TestRun(object testObject)
        {
            Output.WriteLine($"testObject={testObject?.GetType()?.Name?? "null"}");
            TestRunSimple(testObject);
            TestRunShape(testObject);
        }
        [Fact]
        public void TestNull()
        {
            Output.WriteLine("Null Test");

            Output.WriteLine("object x = null;");
            object x = null;

            Output.WriteLine("if (x is null)");
            if (x is null)
                Output.WriteLine("  true");
            else
                Output.WriteLine("  false");

            Output.WriteLine("if (x is var a)");
            if (x is var a)
                Output.WriteLine("  true");
            else
                Output.WriteLine("  false");

            Output.WriteLine("if (x is int b)");
            if (x is int b)
                Output.WriteLine($"  true {b}");
            else
                Output.WriteLine("  false");
            // Output.WriteLine($"typeof(b)={b.GetType().Name}");

            Output.WriteLine("if (x is string c)");
            if (x is int c)
                Output.WriteLine("  true");
            else
                Output.WriteLine("  false");

            
        }

        [Fact]
        public void TestObjectHeadache()
        {
            var testObject = new Circle { Radius = 123 };
            Output.WriteLine("if (testObject is var shape)");
            if (testObject is var shape)
                Output.WriteLine("  true");
            else
                Output.WriteLine("  false");
            if (shape == null)
                Output.WriteLine("shape=null");
            else
            {
                Output.WriteLine($"shape.GetType().Name={shape.GetType().Name}");
                Output.WriteLine($"{JsonConvert.SerializeObject(shape)}");
            }

            if (shape is Circle circle)
            {
                Output.WriteLine($"circle.Radius {circle.Radius} "); ;
            }

        }
        [Fact]
        public void TestObjectNull()
        {
            TestRun(null);
        }

        [Fact]
        public void TestObjectSquare()
        {
            TestRun(new Square());
        }

        [Fact]
        public void TestObjectRectangle()
        {
            TestRun(new Rectangle());
        }

        [Fact]
        public void TestObjectCircle()
        {
            TestRun(new Circle());
        }

        [Fact]
        public void TestObjectString1()
        {
            TestRun(new string('a',10));
        }

        [Fact]
        public void TestObjectString2()
        {
            string a = null;
            TestRun(a);
        }
    }
}
