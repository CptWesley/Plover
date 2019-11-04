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
        private string title;

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
            this.title = title;
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

        /// <summary>
        /// Finalizes an instance of the <see cref="Window"/> class.
        /// </summary>
        ~Window() => Dispose(false);

        /// <summary>
        /// Gets or sets the title of the window.
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                title = value;
                int error = NativeMethods.WebviewSetTitle(ptr, title);
                if (error == 0)
                {
                    throw new InvalidOperationException("Failed to set window title.");
                }
            }
        }

        /// <summary>
        /// Starts rendering the window and perform an action each tick.
        /// </summary>
        /// <param name="onLoad">The action to be performed before rendering.</param>
        public void Render(Action<Window> onLoad)
        {
            if (onLoad == null)
            {
                throw new ArgumentNullException(nameof(onLoad));
            }

            onLoad(this);
            while (NativeMethods.WebviewLoop(ptr, 1) == 0)
            {
            }

            NativeMethods.WebviewExit(ptr);
        }

        /// <summary>
        /// Starts rendering the window and perform an action each tick.
        /// </summary>
        /// <param name="onLoad">The action to be performed on each tick.</param>
        public void Render(Action onLoad) => Render((x) => onLoad());

        /// <summary>
        /// Starts rendering the window.
        /// </summary>
        public void Render() => Render(() => { });

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
            Console.WriteLine(arg);
        }
    }
}
