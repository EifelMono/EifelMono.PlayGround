using EifelMono.PlayGround.TestObjects;
using EifelMono.PlayGround.XCore;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XPatternMatching
{

    public class XIfTestObject : XPlayGround
    {
        public XIfTestObject(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestNotNull()
        {
            try
            {
                Output.WriteLine("if (ResultFilledWithValues() is var result && result.Ok)");
                if (ResultFilledWithValues() is var result && result.Ok)
                    Output.WriteLine("true");
                else
                    Output.WriteLine("false");
            }
            catch
            {
                Output.WriteLine("Exception");
            }
            try
            {
                Output.WriteLine("if (ResultAsNull() is var result && result.Ok)");
                if (ResultAsNull() is var result && result.Ok)
                    Output.WriteLine("true");
                else
                    Output.WriteLine("false");
            }
            catch
            {
                Output.WriteLine("Exception");
            }
            try
            {
                Output.WriteLine("if (ResultAsNull() is Result<string> result && result.Ok)");
                if (ResultAsNull() is Result<string> result && result.Ok)
                    Output.WriteLine("true");
                else
                    Output.WriteLine("false");
            }
            catch
            {
                Output.WriteLine("Exception");
            }
        }


        public Result<string> ResultFilledWithValues()
            => new Result<string> { Ok = true, Value = "" };
        public Result<string> ResultAsNull()
            => null;

    }
    public class Result<T>
    {
        public bool Ok { get; set; } = false;
        public T Value { get; set; }
    }

}
