// <copyright file="IGameAdapter.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>

namespace Contracts.Response
{
    /// <summary>
    /// The repsonse item fro the web calls. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseItem<T> : Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseItem{T}"/> class.
        /// </summary>
        public ResponseItem()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseItem{T}"/> class.
        /// </summary>
        /// <param name="resultCode">The result code.</param>
        /// <param name="description">The description.</param>
        public ResponseItem(ResultCodeEnum resultCode, string description = null)
            : base(resultCode, description)
        { }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data { get; set; }
    }
}
