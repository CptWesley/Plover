using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using Plover.Dom;
using Plover.Events;

namespace Plover
{
    /// <summary>
    /// A wrapper for Plover windows.
    /// </summary>
    public class Window : IDisposable
    {
        private readonly IntPtr ptr;
        private readonly GCHandle gcCallback;

        private bool disposed;
        private string title;
        private bool fullscreen;

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
            NativeMethods.Callback callback = Callback;
            gcCallback = GCHandle.Alloc(callback);
            ptr = NativeMethods.WebviewAlloc(title, url, width, height, resizable ? 1 : 0, 1, callback);
            this.title = title;
            JavaScript = new JavaScript(ptr);
            Document = new Document(JavaScript);
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
                if (NativeMethods.WebviewSetTitle(ptr, title) == 0)
                {
                    throw new InvalidOperationException("Failed to set window title.");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Window"/> is fullscreen.
        /// </summary>
        public bool Fullscreen
        {
            get => fullscreen;
            set
            {
                fullscreen = value;
                if (NativeMethods.WebviewSetFullscreen(ptr, fullscreen ? 1 : 0) == 0)
                {
                    throw new InvalidOperationException("Failed to set window fullscreen mode.");
                }
            }
        }

        /// <summary>
        /// Gets the JavaScript engine instance for this window.
        /// </summary>
        public JavaScript JavaScript { get; }

        /// <summary>
        /// Gets the DOM document.
        /// </summary>
        public Document Document { get; }

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
                gcCallback.Free();
                NativeMethods.WebviewRelease(ptr);
                disposed = true;
            }
        }

        private void Callback(IntPtr webview, string arg)
        {
            JObject payload = JObject.Parse(arg);
            string type = (string)payload["type"];

            if (type == "retrieval")
            {
                string id = (string)payload["id"];
                JToken value = payload["value"];
                JavaScript.SetValue(id, value);
            }
            else if (type == "event")
            {
                HtmlElement target = Document.Elements[(string)payload["id"]];
                JObject args = (JObject)payload["args"];
                target.SendEvent(JsEvents.CreateArguments(args));
            }
        }
    }
}
