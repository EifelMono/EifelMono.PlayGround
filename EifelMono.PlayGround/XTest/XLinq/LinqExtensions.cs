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

        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> thisValue)
            => thisValue.Where(s => s != null);

        public static IEnumerable<TResult> SelectManyNotNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> func)
            => source.WhereNotNull().SelectMany(func);

        public static IEnumerable<TResult> SelectNotNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
            => source.WhereNotNull().Select(func);

        public static IEnumerable<T> Params<T>(Type type, params T[] @params)
            => @params;
    }
}