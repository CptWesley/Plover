using System;
using System.Collections.Generic;
using System.Linq;
using Plover.Events;

namespace Plover.Dom
{
    /// <summary>
    /// Maps an HTML/JS document to C#.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        /// <param name="js">The javascript engine to use.</param>
        internal Document(JavaScript js)
        {
            JavaScript = js;
            Body = InternalCreateElement<Body>();
            JavaScript.Execute("metaIdTable={};metaIdTableReverse={};");
            AddMetaId(Body, "document.body");
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        public Body Body { get; }

        /// <summary>
        /// Gets the JavaScript engine used in the window.
        /// </summary>
        internal JavaScript JavaScript { get; }

        /// <summary>
        /// Gets the element table.
        /// </summary>
        internal Dictionary<string, HtmlElement> Elements { get; } = new Dictionary<string, HtmlElement>();

        /// <summary>
        /// Creates a new HTML element.
        /// </summary>
        /// <typeparam name="T">The specific type of element to create.</typeparam>
        /// <returns>The newly created HTML element.</returns>
        public T CreateElement<T>()
            where T : HtmlElement, new()
        {
            T element = InternalCreateElement<T>();
            AddMetaId(element, $"document.createElement('{element.TagName}')");

            return element;
        }

        /// <summary>
        /// Creates a new HTML element.
        /// </summary>
        /// <param name="tagName">The tag of the HTML element.</param>
        /// <returns>The newly created HTML element.</returns>
        public HtmlElement CreateElement(string tagName)
        {
            HtmlElement element = HtmlElementFactory.Create(tagName);
            element.MetaId = Guid.NewGuid().ToString();
            element.Document = this;
            AddMetaId(element, $"document.createElement('{element.TagName}')");

            return element;
        }

        /// <summary>
        /// Gets the element by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the element.</param>
        /// <returns>The element with the identifier.</returns>
        public HtmlElement GetElementById(string id)
        {
            try
            {
                string metaId = GetMetaIdByExpression($"document.getElementById('{id}')");
                return Elements[metaId];
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Element with id '{id}' does not exist.", nameof(id));
            }
        }

        private static void AddDefaultEvents(HtmlElement element)
        {
            foreach (string sort in JsEvents.GetEvents())
            {
                AddDefaultEvent(element, sort);
            }
        }

        private static void AddDefaultEvent(HtmlElement element, string eventType)
        {
            string[] fields = JsEvents.GetFields(eventType);
            string args = $"{{{string.Join(", ", fields.Select(x => $"{x}: event.{x}"))}}}";
            element.AddEventListener(eventType, $"function(event) {{ external.invoke(JSON.stringify({{type: 'event', id: '{element.MetaId}', args: {args}}})); }}");
        }

        private T InternalCreateElement<T>()
            where T : HtmlElement, new()
            => new T
            {
                MetaId = Guid.NewGuid().ToString(),
                Document = this,
            };

        private void AddMetaId(HtmlElement element, string jsExpression)
        {
            Elements.Add(element.MetaId, element);
            JavaScript.Execute($"metaIdTable['{element.MetaId}'] = {jsExpression};");
            JavaScript.Execute($"metaIdTableReverse[metaIdTable['{element.MetaId}']] = '{element.MetaId}';");
            AddDefaultEvents(element);
        }

        private string GetMetaIdByExpression(string expression)
        {
            bool exists = JavaScript.Execute<bool>($"{expression} instanceof HTMLElement");

            if (!exists)
            {
                throw new ArgumentException("Given expression does not evaluate to an object.", nameof(expression));
            }

            string metaId = JavaScript.Execute<string>($"metaIdTableReverse[{expression}]");
            if (!string.IsNullOrEmpty(metaId))
            {
                return metaId;
            }

            string tag = JavaScript.Execute<string>($"{expression}.tagName");
            HtmlElement element = HtmlElementFactory.Create(tag);
            element.Document = this;
            element.MetaId = Guid.NewGuid().ToString();
            AddMetaId(element, expression);
            return element.MetaId;
        }
    }
}
