namespace Plover.Events
{
    /// <summary>
    /// Delegate for mouse event handlers.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    public delegate void MouseEventHandler(object sender, MouseEventArgs e);

    /// <summary>
    /// Event arguments for events regarding the mouse.
    /// </summary>
    /// <seealso cref="JsEventArgs" />
    public class MouseEventArgs : JsEventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the alt key was pressed during the event.
        /// </summary>
        public bool AltKey { get; internal set; }

        /// <summary>
        /// Gets the button which was pressed during the event.
        /// </summary>
        public int Button { get; internal set; }

        /// <summary>
        /// Gets the buttons which were pressed during the event.
        /// </summary>
        public int Buttons { get; internal set; }

        /// <summary>
        /// Gets the horizontal coordinate of the mouse relative to the window.
        /// </summary>
        public int ClientX { get; internal set; }

        /// <summary>
        /// Gets the vertical coordinate of the mouse relative to the window.
        /// </summary>
        public int ClientY { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the ctrl key was pressed during the event.
        /// </summary>
        public bool CtrlKey { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the meta key was pressed during the event.
        /// </summary>
        public bool MetaKey { get; internal set; }

        /// <summary>
        /// Gets the horizontal coordinate of the mouse relative to the last event.
        /// </summary>
        public int MovementX { get; internal set; }

        /// <summary>
        /// Gets the vertical coordinate of the mouse relative to the last event.
        /// </summary>
        public int MovementY { get; internal set; }

        /// <summary>
        /// Gets the horizontal coordinate of the mouse relative to the edge of the target element.
        /// </summary>
        public int OffsetX { get; internal set; }

        /// <summary>
        /// Gets the vertical coordinate of the mouse relative to the edge of the target element.
        /// </summary>
        public int OffsetY { get; internal set; }

        /// <summary>
        /// Gets the horizontal coordinate of the mouse relative to the page.
        /// </summary>
        public int PageX { get; internal set; }

        /// <summary>
        /// Gets the vertical coordinate of the mouse relative to the page.
        /// </summary>
        public int PageY { get; internal set; }

        /// <summary>
        /// Gets the horizontal coordinate of the mouse relative to the screen.
        /// </summary>
        public int ScreenX { get; internal set; }

        /// <summary>
        /// Gets the vertical coordinate of the mouse relative to the screen.
        /// </summary>
        public int ScreenY { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the shift key was pressed during the event.
        /// </summary>
        public bool ShiftKey { get; internal set; }

        /// <summary>
        /// Gets a value indicating which mouse button was pressed.
        /// </summary>
        public int Which { get; internal set; }
    }
}
