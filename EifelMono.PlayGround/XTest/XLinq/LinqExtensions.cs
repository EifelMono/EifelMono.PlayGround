using System;
using System.Collections.Generic;
using System.Linq;

namespace EifelMono.PlayGround.XTest.XLinq
{
    public static class LinqExtension
    {
        public static IEnumerable<T> NotNull<T>(this IEnumerable<T> thisValue)
            => thisValue.Where(s => s != null);

        public static void Foreach<T>(this List<T> items, Action<T> action)
        {
            foreach (var item in items)
                action?.Invoke(item);
        }

        public static void Foreach<T>(this T[] items, Action<T> action)
        {
            foreach (var item in items)
                action?.Invoke(item);
        }


        /// <summary>
        /// SelectManyNN SelectManyNotNull
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> SelectManyNN<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> func)
            => source.Where(s => s != null).SelectMany(func);

        /// <summary>
        /// SelectNN SelectNotNull
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> SelectNN<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
            => source.Where(s => s != null).Select(func);


    }
}