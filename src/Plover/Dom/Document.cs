using System.Collections.Generic;

namespace Plover.Dom
{
    /// <summary>
    /// Maps an HTML/JS document to C#.
    /// </summary>
    public class Document
    {
        private readonly Dictionary<string, HtmlElement> elements = new Dictionary<string, HtmlElement>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        /// <param name="js">The javascript engine to use.</param>
        internal Document(JavaScript js) => JavaScript = js;

        /// <summary>
        /// Gets the JavaScript engine used in the window.
        /// </summary>
        internal JavaScript JavaScript { get; }

        /// <summary>
        /// Updates the identifier of an element.
        /// </summary>
        /// <param name="oldId">The old identifier.</param>
        /// <param name="newId">The new identifier.</param>
        internal void UpdateId(string oldId, string newId)
        {
            HtmlElement element = elements[oldId];
            elements.Remove(oldId);
            elements[newId] = element;
        }

        /*
        private bool Exists(string id)
        {
            JavaScript.Execute<object>($"document.getElementById('{id}')");
        }

        public HtmlElement GetElementById(string id)
        {
            JavaScript.Execute<object>($"document.getElementById('{id}')");
        }
        */
    }
}
