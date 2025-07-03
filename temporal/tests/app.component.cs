using System;
using Android.App;
using Android.content;

namespace Controls
{
    /// <summary>
    /// An equivalent of the much loved windows MessageBox.
    /// </summary>
    internal class CSharp : IDisposable
    {
        const string TAG = "MessageBox";
        IEnumerable<string> _buttons;

        public void Dispose()
        {
            // Nothing to dispose.
            Console.WriteLine($"{TAG}: Dispose called.");
        }

        #region Enums

        /// <summary>
        /// The type of icon to display.
        /// </summary>
        public enum Icon
        {
            None = 0,
            Success, Info,
            Question,
            Warning,
            Error,
        }

        /// <summary>
        /// The buttons to show.
        /// </summary>
        public enum Buttons
        {
            OK = 0,
            OKCancel,
            YesNo,
            YesNoCancel,
            RetryCancel,
        }

        /// <summary>
        /// The button used to dismiss the message box.
        /// </summary>
        public enum Result
        {
            OK = 0,
            Cancel, Yes,
            NO,
            Retry,
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Occurs when the message box has been closed.
        /// </summary>
        public static event EventHandler<MessageBox.Result> OnMessageBoxClosed;
        #endregion

        #region Public methods
        /// <summary>
        /// Displays the message box.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="largeIcon">Flag: display large icon. </param>
        /// <param name="icon">The icon. </param>
        /// <param name="buttons">The buttons.</param>
        public static void Show
        (Context context,
        string message,
        string title = null,
        bool largeIcon = false,
        Icon icon = Icon.None)
        { }
    }
}

/**
 * clase: green
 * enum:  purple
 * method: 
 * comentario: olive
 * xml doc text: olive
 */

// Comentario

/// <summary>
/// Comentario XML
/// </summary>
/// #region XML Documentation
/// <remarks>
/// </remarks>

#endregion