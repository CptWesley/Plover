using System.Collections;
using System.Collections.Generic;

namespace Plover.Dom
{
    /// <summary>
    /// Class representing HTML element collections.
    /// </summary>
    /// <typeparam name="T">The type of HTML element in the collection.</typeparam>
    public class HtmlCollection<T> : IEnumerable<T>
        where T : HtmlElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlCollection{T}"/> class.
        /// </summary>
        /// <param name="jsExpression">The JavaScript expression.</param>
        public HtmlCollection(string jsExpression)
            => Expression = jsExpression;

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        internal Document Document { get; set; }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        protected string Expression { get; }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            int length = Document.JavaScript.Execute<int>($"{Expression}.length");
            for (int i = 0; i < length; i++)
            {
                yield return (T)Document.GetElementByExpression($"{Expression}.item({i})");
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Class representing HTML element collections.
    /// </summary>
    /// <seealso cref="IEnumerable{T}" />
    public class HtmlCollection : HtmlCollection<HtmlElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlCollection"/> class.
        /// </summary>
        /// <param name="jsExpression">The JavaScript expression.</param>
        public HtmlCollection(string jsExpression)
            : base(jsExpression)
        {
        }
    }
}
