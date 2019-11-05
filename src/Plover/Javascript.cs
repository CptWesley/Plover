﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Plover
{
    /// <summary>
    /// Execution engine for JavaScript in windows.
    /// </summary>
    public class JavaScript
    {
        private readonly IntPtr webview;
        private readonly Dictionary<string, string> retrievals = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScript"/> class.
        /// </summary>
        /// <param name="webview">The webview pointer.</param>
        internal JavaScript(IntPtr webview) => this.webview = webview;

        /// <summary>
        /// Executes the specified JavaScript code.
        /// </summary>
        /// <param name="js">The JavaScript code to execute.</param>
        public void Execute(string js)
        {
            if (NativeMethods.WebviewEval(webview, js) != 0)
            {
                throw new ArgumentException($"An error occured while executing JavaScript code.");
            }
        }

        /// <summary>
        /// Executes the specified JavaScript and gives the return value.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="js">The JavaScript code to execute.</param>
        /// <returns>The returned value.</returns>
        public T Execute<T>(string js)
        {
            string id = Guid.NewGuid().ToString();

            try
            {
                Execute($"external.invoke(JSON.stringify({{type: 'retrieval', id: '{id}', value: JSON.stringify({js})}}))");
                return JsonConvert.DeserializeObject<T>(retrievals[id]);
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
        internal void SetValue(string id, string value) => retrievals[id] = value;
    }
}
