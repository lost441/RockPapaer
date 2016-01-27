// <copyright file="Result.cs" company="PayM8">
//     Copyright ©  2016
// </copyright>
namespace Contracts.Response
{
    using System.Collections.Generic;
    using Common;

    /// <summary>
    /// Teh result object.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        public Result()
        {
            Errors = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="resultCode">The result code.</param>
        /// <param name="description">The description.</param>
        public Result(ResultCodeEnum resultCode, string description = null)
            : this()
        {
            this.IsSuccessfull = resultCode.GetSuccess();
            this.ResultCode = resultCode.ToDescription();
            this.ResultDescription = description;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is successfull.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is successfull; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccessfull { get; set; }

        /// <summary>
        /// Gets or sets the result code.
        /// </summary>
        /// <value>
        /// The result code.
        /// </value>
        public string ResultCode { get; set; }

        /// <summary>
        /// Gets or sets the result description.
        /// </summary>
        /// <value>
        /// The result description.
        /// </value>
        public string ResultDescription { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable<string> Errors { get; set; }
    }
}
