using System;
using EifelMono.PlayGround.XCore;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using System.Diagnostics;

namespace EifelMono.PlayGround.XTest.XNewtonsoft
{
    public class XSerializeDeserialize : XPlayGround
    {
        public XSerializeDeserialize(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void TestSerialLizeWithpPrivateParameterlessConstructor()
        {
            TryCatch(() =>
            {
                var test = Test.Create("Andreas", "Klapperich");
                test.Cip = "56745";
                test.City = "Rieden";
                var json = JsonConvert.SerializeObject(test);
                var newObject = JsonConvert.DeserializeObject<Test>(json);
            });
        }

        public class Test
        {
            public static Test Create() => new Test();
            public static Test Create(string firstName, string lastName) => new Test(firstName, lastName);

            private Test()
            {
                Debug.WriteLine($"Test() created");
            }

            private Test(string firstName, string lastName)
            {
                Debug.WriteLine($"Test({firstName},{lastName}) created");
                FirstName = firstName;
                LastName = lastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Cip { get; set; }
            public string City { get; set; }


            [JsonIgnore]
            public string FullName => $"{FirstName} {LastName}";
        }
    }
}
