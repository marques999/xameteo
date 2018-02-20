using System;

using Xameteo.API;
using Xamarin.Forms;

namespace Xameteo
{
    /// <summary>
    /// </summary>
    public class XameteoEvents
    {
        /// <summary>
        /// </summary>
        private const string ViewTag = "view_location";
        private const string InsertTag = "insert_location";
        private const string RemoveTag = "remove_location";
        private const string RefreshTag = "refresh_location";

        /// <summary>/ 
        /// </summary>
        /// <param name="index"></param>
        public void Refresh(int index) => MessagingCenter.Send(this, RefreshTag, index);

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        public void View(ApixuPlace adapter) => MessagingCenter.Send(this, ViewTag, adapter);

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        public void Insert(ApixuPlace adapter) => MessagingCenter.Send(this, InsertTag, adapter);

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        public void Remove(ApixuPlace adapter) => MessagingCenter.Send(this, RemoveTag, adapter);

        /// <summary>
        /// </summary>
        /// <param name="callback"></param>
        public void SubscribeView(Action<XameteoEvents, ApixuPlace> callback)
        {
            MessagingCenter.Subscribe(this, ViewTag, callback);
        }

        /// <summary>
        /// </summary>
        /// <param name="callback"></param>
        public void SubscribeRefresh(Action<XameteoEvents, int> callback)
        {
            MessagingCenter.Subscribe(this, RefreshTag, callback);
        }

        /// <summary>
        /// </summary>
        /// <param name="insertHandler"></param>
        /// <param name="removeHandler"></param>
        public void SubscribeUpdates(Action<XameteoEvents, ApixuPlace> insertHandler, Action<XameteoEvents, ApixuPlace> removeHandler)
        {
            MessagingCenter.Subscribe(this, InsertTag, insertHandler);
            MessagingCenter.Subscribe(this, RemoveTag, removeHandler);
        }
    }
}