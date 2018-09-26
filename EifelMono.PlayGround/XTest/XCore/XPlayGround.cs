using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XCore
{
    public class XPlayGround
    {
        protected readonly ITestOutputHelper Output;

        public XPlayGround(ITestOutputHelper output)
        {
            this.Output = output;
        }

        public void WriteLine(string text= "")
            => Output.WriteLine(text);

        public void Line(int count=80)
            => Output.WriteLine(new string('-', count));

        public void DoubleLine(int count = 80)
          => Output.WriteLine(new string('=', count));

        public void Dump(object dump)
            => Output.WriteLine(JsonConvert.SerializeObject(dump, Formatting.Indented));

        public void TryCatch(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception ex)
            {
                Output.WriteLine(ex.ToString());
                throw new Xunit.Sdk.XunitException(ex.ToString());
            }
        }
    }
}
