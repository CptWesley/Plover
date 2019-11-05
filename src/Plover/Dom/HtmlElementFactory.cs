using System;

namespace Plover.Dom
{
    /// <summary>
    /// Factory for creating html elements.
    /// </summary>
    public static class HtmlElementFactory
    {
        /// <summary>
        /// Creates the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>A new HTML element.</returns>
        public static HtmlElement Create(string tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            switch (tag.ToUpperInvariant().Trim())
            {
                case "BODY": return new Body();
                case "BUTTON": return new Button();
                default: return new UnknownElement(tag);
            }
        }
    }
}
