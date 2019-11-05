namespace Plover.Dom
{
    /// <summary>
    /// Class for HTML elements of unknown nature.
    /// </summary>
    /// <seealso cref="HtmlElement" />
    public class UnknownElement : HtmlElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownElement"/> class.
        /// </summary>
        /// <param name="tagName">The tag.</param>
        public UnknownElement(string tagName)
            : base(tagName)
        {
        }
    }
}
