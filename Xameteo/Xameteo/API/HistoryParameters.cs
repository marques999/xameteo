using System;
using Refit;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class HistoryParameters
    {
        /// <summary>
        /// </summary>
        [AliasAs("dt")]
        public DateTime Start
        {
            get;
        }

        /// <summary>
        /// </summary>
        [AliasAs("dt_end")]
        public DateTime End
        {
            get;
        }

        /// <summary>
        /// </summary>
        public HistoryParameters(DateTime start, DateTime end)
        {
            End = end;
            Start = start;
        }
    }
}