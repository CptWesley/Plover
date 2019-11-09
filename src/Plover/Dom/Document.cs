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
            JavaScript.Execute("metaIdTable=new Map();metaIdTableReverse=new Map();");
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
            => GetElementByExpression($"document.getElementById('{id}')");

        /// <summary>
        /// Gets the element by identifier.
        /// </summary>
        /// <typeparam name="T">Type of the element.</typeparam>
        /// <param name="id">The identifier of the element.</param>
        /// <returns>The element of the given type.</returns>
        public T GetElementById<T>(string id)
            where T : HtmlElement
            => (T)GetElementById(id);

        /// <summary>
        /// Gets a collection of HTML elements with a given tag name.
        /// </summary>
        /// <param name="tagName">Tag name of the elements.</param>
        /// <returns>A collection of HTML elements.</returns>
        public HtmlCollection GetElementsByTagName(string tagName)
            => new HtmlCollection($"document.getElementsByTagName('{tagName}')")
            {
                Document = this,
            };

        /// <summary>
        /// Gets a collection of HTML elements with a given type.
        /// </summary>
        /// <typeparam name="T">The type of HTML elements to get.</typeparam>
        /// <returns>A collection of HTML elements.</returns>
        public HtmlCollection<T> GetElementsByTagName<T>()
            where T : HtmlElement
            => new HtmlCollection<T>($"document.getElementsByTagName('{HtmlElementFactory.GetTag<T>()}')")
            {
                Document = this,
            };

        /// <summary>
        /// Gets an HTML element from a js expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>The HTML element.</returns>
        internal HtmlElement GetElementByExpression(string expression)
        {
            bool exists = JavaScript.Execute<bool>($"{expression} instanceof HTMLElement");

            if (!exists)
            {
                throw new ArgumentException("Given expression does not evaluate to an object.", nameof(expression));
            }

            string metaId = JavaScript.Execute<string>($"metaIdTableReverse.get({expression})");
            if (!string.IsNullOrEmpty(metaId))
            {
                return Elements[metaId];
            }

            string tag = JavaScript.Execute<string>($"{expression}.tagName");
            HtmlElement element = HtmlElementFactory.Create(tag);
            element.Document = this;
            element.MetaId = Guid.NewGuid().ToString();
            AddMetaId(element, expression);
            return element;
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
            JavaScript.Execute($"metaIdTable.set('{element.MetaId}', {jsExpression});");
            JavaScript.Execute($"metaIdTableReverse.set(metaIdTable.get('{element.MetaId}'), '{element.MetaId}');");
            AddDefaultEvents(element);
        }
    }
}
