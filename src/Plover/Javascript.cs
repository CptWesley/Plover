using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Plover
{
    /// <summary>
    /// Execution engine for JavaScript in windows.
    /// </summary>
    public class JavaScript
    {
        private readonly IntPtr webview;
        private readonly Dictionary<string, JToken> retrievals = new Dictionary<string, JToken>();

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScript"/> class.
        /// </summary>
        /// <param name="webview">The webview pointer.</param>
        internal JavaScript(IntPtr webview) => this.webview = webview;

        /// <summary>
        /// Executes the specified JavaScript code.
        /// </summary>
        /// <param name="jsStataments">The JavaScript stataments to execute.</param>
        public void Execute(string jsStataments)
        {
            if (NativeMethods.WebviewEval(webview, jsStataments) != 0)
            {
                throw new ArgumentException($"An error occured while executing JavaScript code.");
            }
        }

        /// <summary>
        /// Executes the specified JavaScript and gives the return value.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="jsExpression">The JavaScript expression to evaluate.</param>
        /// <returns>The returned value.</returns>
        public T Execute<T>(string jsExpression)
        {
            string id = Guid.NewGuid().ToString();

            try
            {
                Execute($"external.invoke(JSON.stringify({{type: 'retrieval', id: '{id}', value: {jsExpression}}}))");

                JToken value = retrievals[id];
                if (value == null)
                {
                    return default;
                }

                return value.ToObject<T>();
            }
            finally
            {
                retrievals.Remove(id);
            }
        }

        /// <summary>
        /// Sets the value of a retrieval.
        /// </summary>
        /// <param name="id">The identifier of the retrieval.</param>
        /// <param name="value">The value.</param>
        internal void SetValue(string id, JToken value) => retrievals[id] = value;
    }
}
