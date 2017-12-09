using System;
using Xamarin.Forms;
using Xameteo.API;

namespace Xameteo.Helpers
{
    public interface IEventObject
    {
        
    }
    /// <summary>
    /// </summary>
    internal class Events
    {
        /// <summary>
        /// </summary>
        private const string ViewLocationTag = "view_location";
        private const string InsertLocationTag = "insert_location";

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="apixuAdapter"></param>
        public void ViewLocation(IEventObject source, ApixuAdapter apixuAdapter)
        {
            MessagingCenter.Send(source, ViewLocationTag, apixuAdapter);
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="apixuAdapter"></param>
        public void InsertLocation(IEventObject source, ApixuAdapter apixuAdapter)
        {
            MessagingCenter.Send(source, InsertLocationTag, apixuAdapter);
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="callback"></param>
        public void SubscribeViewLocation(IEventObject source, Action<IEventObject, ApixuAdapter> callback)
        {
            MessagingCenter.Subscribe(this, ViewLocationTag, callback);
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="callback"></param>
        public void SubscribeInsertLocation(IEventObject source, Action<IEventObject, ApixuAdapter> callback)
        {
            MessagingCenter.Subscribe(this, InsertLocationTag, callback);
        }
    }
}