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
        private bool fullscreen = false;

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

            return new Window(title, url, width, height, resizable)
            {
                Fullscreen = fullscreen,
            };
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
        public WindowBuilder FromUrl(string url)
        {
            this.url = url;
            return this;
        }

        /// <summary>
        /// Sets the URL of the window.
        /// </summary>
        /// <param name="uri">The URI of the window.</param>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder FromUrl(Uri uri)
        {
            this.url = uri?.AbsoluteUri;
            return this;
        }

        /// <summary>
        /// Sets the HTML content of the window.
        /// </summary>
        /// <param name="html">The HTML content.</param>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder FromHtml(string html)
        {
            this.url = UrlFromHtml(html);
            return this;
        }

        /// <summary>
        /// Sets the url to a file path.
        /// </summary>
        /// <param name="fileName">The path to the file containing HTML.</param>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder FromFile(string fileName)
        {
            this.url = $"file:///{fileName}";
            return this;
        }

        /// <summary>
        /// Sets the default windowing mode of the window to fullscreen.
        /// </summary>
        /// <returns>The same <see cref="WindowBuilder"/> instance.</returns>
        public WindowBuilder IsFullscreen()
        {
            this.fullscreen = true;
            return this;
        }

        private static string UrlFromHtml(string html) => $"data:text/html,{Uri.EscapeDataString(html)}";
    }
}
