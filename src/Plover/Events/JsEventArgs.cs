using System;

namespace Plover.Events
{
    /// <summary>
    /// Event arguments for JavaScript events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public abstract class JsEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the type of event.
        /// </summary>
        public string Type { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the event is trusted.
        /// </summary>
        /// <value><c>true</c> if this instance is trusted; otherwise, <c>false</c>.</value>
        public bool IsTrusted { get; internal set; }
    }
}
