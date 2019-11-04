using System;

namespace Plover
{
    /// <summary>
    /// A wrapper for Plover windows.
    /// </summary>
    public class Window : IDisposable
    {
        private readonly IntPtr ptr;

        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="url">The URL of the window.</param>
        /// <param name="width">The width of the window.</param>
        /// <param name="height">The height of the window.</param>
        /// <param name="resizable">Indicates if the window should be resizable.</param>
        public Window(string title, string url, int width, int height, bool resizable)
        {
            ptr = NativeMethods.WebviewAlloc(title, url, width, height, resizable ? 1 : 0, 1, Callback);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="uri">The URI of the window.</param>
        /// <param name="width">The width of the window.</param>
        /// <param name="height">The height of the window.</param>
        /// <param name="resizable">Indicates if the window should be resizable.</param>
        public Window(string title, Uri uri, int width, int height, bool resizable)
            : this(title, uri?.AbsoluteUri, width, height, resizable)
        {
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                NativeMethods.WebviewRelease(ptr);
                disposed = true;
            }
        }

        private void Callback(IntPtr webview, string arg)
        {

        }
    }
}
