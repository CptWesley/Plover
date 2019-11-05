using System;

namespace Plover.Dom
{
    public abstract class HtmlElement
    {
        public event EventHandler OnClick;

        private readonly Document document;
        private readonly bool inDom;

        private string id;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement"/> class.
        /// </summary>
        /// <param name="document">The parent DOM document.</param>
        public HtmlElement(string id, Document document)
        {
            this.document = document;
            this.id = id;
        }

        public string Id
        {
            get => id;
            set
            {
                id = value;

                if (inDom)
                {
                    document.JavaScript.Execute($"document.getElementById('{id}').id = '{id}';");
                }
            }
        }
    }
}
