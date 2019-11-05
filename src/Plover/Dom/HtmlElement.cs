#pragma warning disable CS0067

using System;
using System.Reflection;
using Plover.Events;

namespace Plover.Dom
{
    /// <summary>
    /// Abstract class for HTML elements.
    /// </summary>
    public abstract class HtmlElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement"/> class.
        /// </summary>
        /// <param name="tagName">The tag.</param>
        public HtmlElement(string tagName)
        {
            TagName = tagName;
        }

        /// <summary>
        /// Occurs when the element is clicked.
        /// </summary>
        public event MouseEventHandler OnClick;

        /// <summary>
        /// Gets the tag.
        /// </summary>
        public string TagName { get; }

        /// <summary>
        /// Gets the meta identifier.
        /// </summary>
        public string MetaId { get; internal set; }

        /// <summary>
        /// Gets or sets the inner HTML.
        /// </summary>
        public string InnerHtml { get => GetField("innerHTML"); set => SetField("innerHTML", value); }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get => GetField("id"); set => SetField("id", value); }

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        internal Document Document { get; set; }

        /// <summary>
        /// Appends a child node.
        /// </summary>
        /// <param name="element">The element to append.</param>
        public void AppendChild(HtmlElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            Document.JavaScript.Execute($"metaIdTable['{MetaId}'].appendChild(metaIdTable['{element.MetaId}']);");
        }

        /// <summary>
        /// Adds an event listener.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="jsHandler">The js handler.</param>
        public void AddEventListener(string eventType, string jsHandler) => Call($"addEventListener('{eventType}', {jsHandler})");

        /// <summary>
        /// Sends the event.
        /// </summary>
        /// <param name="e">The arguments of the event.</param>
        internal void SendEvent(JsEventArgs e)
        {
            FieldInfo field = typeof(HtmlElement).GetField($"on{e.Type}", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
            if (field != null)
            {
                MulticastDelegate eventDelegate = (MulticastDelegate)field.GetValue(this);

                if (eventDelegate != null)
                {
                    eventDelegate.DynamicInvoke(this, e);
                }
            }
        }

        private void SetField(string field, string value)
            => Document.JavaScript.Execute($"metaIdTable['{MetaId}'].{field} = '{value}';");

        private string GetField(string field)
            => Document.JavaScript.Execute<string>($"metaIdTable['{MetaId}'].{field}");

        private void Call(string call)
            => Document.JavaScript.Execute($"metaIdTable['{MetaId}'].{call};");
    }
}

#pragma warning restore CS0067