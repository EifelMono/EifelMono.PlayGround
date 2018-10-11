using System;
using System.Collections.Generic;
using System.Text;
using EifelMono.PlayGround.TestObjects;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XOthers
{
    public class XIsInherited : XPlayGround
    {
        public XIsInherited(ITestOutputHelper output) : base(output) { }
        [Fact]
        public void Test1()
        {
            var shape = new Shape();
            var circle = new Circle();
            var square = new Square();
            var rectangle = new Rectangle();

            Assert.True(circle.GetType().IsSubclassOf(typeof(Shape)));
            Assert.True(square.GetType().IsSubclassOf(typeof(Shape)));

            Assert.True(rectangle.GetType().IsSubclassOf(typeof(Shape)));
            Assert.True(rectangle.GetType().IsSubclassOf(typeof(Square)));
            Assert.True(rectangle.GetType().IsSubclassOf(shape.GetType()));
            Assert.True(rectangle.GetType().IsSubclassOf(square.GetType()));
        }
    }
}
