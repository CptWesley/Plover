using System;

namespace Plover
{
    /// <summary>
    /// A builder for <see cref="Window"/> instances.
    /// </summary>
    public class WindowBuilder
    {
        private int width = 800;
        private int height = 600;
        private bool resizable = true;
        private string title = "Plover App";
        private string url = string.Empty;

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>A new <see cref="Window"/> instance.</returns>
        public Window Build()
        {
            string url = this.url.Trim();

            if (string.IsNullOrEmpty(url))
            {
                url = UrlFromHtml("<html></html>");
            }

            return new Window(title, url, width, height, resizable);
        }

        /// <summary>
        /// Sets the title of the window.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        /// <summary>
        /// Determines whether the window should be resizable.
        /// </summary>
        /// <param name="resizable">Indicates whether the window should be resizable.</param>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder IsResizable(bool resizable)
        {
            this.resizable = resizable;
            return this;
        }

        /// <summary>
        /// Sets the size of the window.
        /// </summary>
        /// <param name="width">The width of the window.</param>
        /// <param name="height">The height of the window.</param>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder WithSize(int width, int height)
        {
            this.width = width;
            this.height = height;
            return this;
        }

        /// <summary>
        /// Sets the URL of the window.
        /// </summary>
        /// <param name="url">The URL of the window.</param>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder WithUrl(string url)
        {
            this.url = url;
            return this;
        }

        /// <summary>
        /// Sets the URL of the window.
        /// </summary>
        /// <param name="uri">The URI of the window.</param>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder WithUrl(Uri uri)
        {
            this.url = uri?.AbsoluteUri;
            return this;
        }

        /// <summary>
        /// Sets the HTML content of the window.
        /// </summary>
        /// <param name="html">The HTML content.</param>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder WithHtml(string html)
        {
            this.url = UrlFromHtml(html);
            return this;
        }

        private static string UrlFromHtml(string html) => $"data:text/html,{Uri.EscapeDataString(html)}";
    }
}
