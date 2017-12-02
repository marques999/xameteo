using System.Collections.Generic;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this List<T> list)
        {
            return list == null || list.Count < 1;
        }
    }
}