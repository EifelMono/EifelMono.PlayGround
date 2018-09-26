using System;
using System.Collections.Generic;
using System.Text;

namespace EifelMono.PlayGround.TestObjects
{
    public class ClassA
    {
        public string NameA { get; set; }

        public List<ClassB> ClassBs { get; set; } = new List<ClassB>();
    }
}
