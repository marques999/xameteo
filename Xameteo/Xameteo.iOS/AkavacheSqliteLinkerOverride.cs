using System;
using Akavache.Sqlite3;

namespace Xameteo.iOS
{
    /// <summary>
    /// </summary>
    [Preserve]
    public static class LinkerPreserve
    {
        /// <summary>
        /// </summary>
        static LinkerPreserve()
        {
            throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
        }
    }

    /// <summary>
    /// </summary>
    public class PreserveAttribute : Attribute
    {
    }
}