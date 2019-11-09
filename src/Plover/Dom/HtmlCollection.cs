using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
        /// Gets the length of the collection.
        /// </summary>
        public int Length => Document.JavaScript.Execute<int>($"{Expression}.length");

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        internal Document Document { get; set; }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        protected string Expression { get; }

        /// <summary>
        /// Gets the element at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The element at the given index.</returns>
        [IndexerName("IndexerItem")]
        public T this[int index]
        {
            get => Item(index);
        }

        /// <summary>
        /// Gets the element with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The element with the given identifier.</returns>
        [IndexerName("IndexerItem")]
        public T this[string id]
        {
            get => NamedItem(id);
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return Item(i);
            }
        }

        /// <summary>
        /// Gets the element at the given index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The element at the given index.</returns>
        public T Item(int index)
            => (T)Document.GetElementByExpression($"{Expression}.item({index})");

        /// <summary>
        /// Gets the element with the given identifier.
        /// </summary>
        /// <param name="id">The identifier of the element.</param>
        /// <returns>The element with the given identifier.</returns>
        public T NamedItem(string id)
            => (T)Document.GetElementByExpression($"{Expression}.namedItem('{id}')");

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
