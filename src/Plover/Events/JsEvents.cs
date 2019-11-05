using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Plover.Events
{
    /// <summary>
    /// Helper class for dealing with js events.
    /// </summary>
    public static class JsEvents
    {
        private static readonly Dictionary<Type, string[]> TypeToEvents = new Dictionary<Type, string[]>()
        {
            { typeof(MouseEventArgs), new[] { "click", "contextmenu", "dblclick", "mousedown", "mouseenter", "mouseleave", "mousemove", "mouseout", "mouseover", "mouseup" } },
        };

        private static readonly Dictionary<string, Type> EventToType = new Dictionary<string, Type>();

        static JsEvents()
        {
            foreach (KeyValuePair<Type, string[]> pair in TypeToEvents)
            {
                foreach (string sort in pair.Value)
                {
                    EventToType.Add(sort, pair.Key);
                }
            }
        }

        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <returns>An array with all events.</returns>
        internal static string[] GetEvents()
            => EventToType.Select(x => x.Key).ToArray();

        /// <summary>
        /// Finds the event arguments type corresponding with the event type.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <returns>The type of the arguments corresponding to the event type.</returns>
        internal static Type GetArgumentsType(string eventType) => EventToType[eventType];

        /// <summary>
        /// Gets an array with all fields on the event.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <returns>An array with all fields of the event args.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1308", Justification = "Not used for comparisons.")]
        internal static string[] GetFields(string eventType)
            => GetArgumentsType(eventType).GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Select(x => x.Name.Substring(0, 1).ToLowerInvariant() + x.Name.Substring(1)).ToArray();

        /// <summary>
        /// Creates event arguments objects.
        /// </summary>
        /// <param name="json">The json object.</param>
        /// <returns>An event arguments instance.</returns>
        internal static JsEventArgs CreateArguments(JObject json)
        {
            Type type = EventToType[(string)json["type"]];
            JsEventArgs result = (JsEventArgs)Activator.CreateInstance(type);

            foreach (KeyValuePair<string, JToken> pair in json)
            {
                PropertyInfo property = type.GetProperty(pair.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                property.SetValue(result, pair.Value.ToObject(property.PropertyType));
            }

            return result;
        }
    }
}
