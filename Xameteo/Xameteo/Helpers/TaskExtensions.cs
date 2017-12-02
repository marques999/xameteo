using System.Threading.Tasks;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tcs"></param>
        /// <returns></returns>
        public static bool IsNullFinishCanceledOrFaulted<T>(this TaskCompletionSource<T> tcs)
        {
            return tcs == null || (int)tcs.Task.Status >= 5;
        }
    }
}