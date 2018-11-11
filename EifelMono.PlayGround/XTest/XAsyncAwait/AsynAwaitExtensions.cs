using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EifelMono.PlayGround.XTest.XAsyncAwait
{
    public static class AsynAwaitExtensions
    {
        #region https://mariusgundersen.net/duck-extensions/
        public static TaskAwaiter<T> GetAwaiter<T>(this T nonAwaitable)
            => Task.FromResult(nonAwaitable).GetAwaiter();
        public static TaskAwaiter<T> GetAwaiter<T>(this Lazy<Task<T>> lazyTask)
            => lazyTask.Value.GetAwaiter();
        #endregion
    }
}
