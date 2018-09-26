using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EifelMono.PlayGround.TestObjects
{
    public class ClassB
    {
        public string NameB { get; set; }

        public List<ClassC> ClassCs { get; set; } = new List<ClassC>();
    }
}
