using System;
using Xamarin.Forms;
using Xameteo.API;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    public interface IEventObject
    {
    }

    /// <summary>
    /// </summary>
    public class Events
    {
        /// <summary>
        /// </summary>
        private const string ViewTag = "view_location";
        private const string InsertTag = "insert_location";
        private const string RemoveTag = "remove_location";

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="adapter"></param>
        public void View(IEventObject source, ApixuAdapter adapter) => MessagingCenter.Send(source, ViewTag, adapter);

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="adapter"></param>
        public void Insert(IEventObject source, ApixuAdapter adapter) => MessagingCenter.Send(source, InsertTag, adapter);

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="adapter"></param>
        public void Remove(IEventObject source, ApixuAdapter adapter) => MessagingCenter.Send(source, RemoveTag, adapter);

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="callback"></param>
        public void SubscribeView(IEventObject source, Action<IEventObject, ApixuAdapter> callback)
        {
            MessagingCenter.Subscribe(this, ViewTag, callback);
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="insertHandler"></param>
        /// <param name="removeHandler"></param>
        public void SubscribeUpdates(IEventObject source,
            Action<IEventObject, ApixuAdapter> insertHandler,
            Action<IEventObject, ApixuAdapter> removeHandler
        )
        {
            MessagingCenter.Subscribe(this, InsertTag, insertHandler);
            MessagingCenter.Subscribe(this, RemoveTag, removeHandler);
        }
    }
}