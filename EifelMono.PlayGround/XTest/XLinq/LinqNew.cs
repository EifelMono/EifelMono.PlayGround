using System.Collections.Generic;
using System.Linq;

namespace EifelMono.PlayGround.XTest.XLinq
{
    public static class LinqNew
    {
        public static IEnumerable<T> Params<T>(params T[] @params)
            => @params;

        public static IEnumerable<int> Range(int start, int count)
            => Enumerable.Range(start, count);
    }
}
