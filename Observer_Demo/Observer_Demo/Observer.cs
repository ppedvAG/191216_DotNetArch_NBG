using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Demo
{
    public struct SubscriberItem
    {
        public object Subscriber { get; set; }
        public string Message { get; set; }
        public Action<object> Callback { get; set; }
    }

    public static class Observer
    {

        private static List<SubscriberItem> subscribers = new List<SubscriberItem>();
        public static void Subscribe(object subscriber, string Message, Action<object> Callback)
        {
            // Todo: Auf doppelte Einträge prüfen
            subscribers.Add(new SubscriberItem { Subscriber = subscriber, Message = Message, Callback = Callback });
        }
        public static void Unsubscribe(object subscriber, string Message)
        {
            var unsub = subscribers.Where(x => x.Subscriber == subscriber && x.Message == Message).ToArray();
            foreach (var item in unsub)
                subscribers.Remove(item); // Inkl Duplikate
        }

        public static void Publish(string Message, object param)
        {
            foreach (var sub in subscribers.Where(x => x.Message == Message))
            {
                sub.Callback(param);
            }
        }
    }
}