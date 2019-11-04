using System;
using System.Runtime.InteropServices;

namespace Plover
{
    /// <summary>
    /// Internal class containing bindings for webview.
    /// </summary>
    internal static class NativeMethods
    {
        private const string DllName = "webview";

        /// <summary>
        /// Delegate for callbacks.
        /// </summary>
        /// <param name="webview">The webview.</param>
        /// <param name="arg">The argument.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal delegate void Callback(IntPtr webview, string arg);

        /// <summary>
        /// Allocates a new webview.
        /// </summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="url">The URL to be loaded.</param>
        /// <param name="width">The width of the window.</param>
        /// <param name="height">The height of the window.</param>
        /// <param name="resizable">Indicates if the window should be resizable or not.</param>
        /// <param name="debug">Indicates whether or not debug mode is enabled.</param>
        /// <param name="cb">The cb.</param>
        /// <returns>A pointer to the created webview.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "webview_alloc")]
        internal static extern IntPtr WebviewAlloc(string title, string url, int width, int height, int resizable, int debug, Callback cb);

        /// <summary>
        /// Release a webview.
        /// </summary>
        /// <param name="webview">The webview pointer.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "webview_release")]
        internal static extern void WebviewRelease(IntPtr webview);

        /// <summary>
        /// Performs a single loop.
        /// </summary>
        /// <param name="webview">The webview pointer.</param>
        /// <param name="blocking">Integer indicating whether or not the cycle should be blocking.</param>
        /// <returns>An integer indicating success.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "webview_loop")]
        internal static extern int WebviewLoop(IntPtr webview, int blocking);

        /// <summary>
        /// Evaluates javascript in the webview.
        /// </summary>
        /// <param name="webview">The webview pointer.</param>
        /// <param name="js">The javascript snippet.</param>
        /// <returns>An integer indicating success.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "webview_eval")]
        internal static extern int WebviewEval(IntPtr webview, string js);

        /// <summary>
        /// Injects css to the webview.
        /// </summary>
        /// <param name="webview">The webview pointer.</param>
        /// <param name="css">The CSS code.</param>
        /// <returns>An integer indicating success.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "webview_inject_css")]
        internal static extern int WebviewInjectCss(IntPtr webview, string css);

        /// <summary>
        /// Sets the title of a webview.
        /// </summary>
        /// <param name="webview">The webview pointer.</param>
        /// <param name="title">The title.</param>
        /// <returns>An integer indicating success.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "webview_set_title")]
        internal static extern int WebviewSetTitle(IntPtr webview, string title);

        /// <summary>
        /// Sets the fullscreen mode of the webview.
        /// </summary>
        /// <param name="webview">The webview pointer.</param>
        /// <param name="fullscreen">Indicates whether or not fullscreen mode should be enabled..</param>
        /// <returns>An integer indicating success.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "webview_set_fullscreen")]
        internal static extern int WebviewSetFullscreen(IntPtr webview, int fullscreen);

        /// <summary>
        /// Exits a webview.
        /// </summary>
        /// <param name="webview">The webview pointer.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "webview_exit")]
        internal static extern void WebviewExit(IntPtr webview);
    }
}
