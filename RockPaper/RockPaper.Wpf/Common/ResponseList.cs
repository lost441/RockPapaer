using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaper.Wpf.Common
{
    /// <summary>
    /// Response list class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseList<T>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is successfull.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is successfull; otherwise, <c>false</c>.
        /// </value>
        public bool isSuccessfull { get; set; }

        /// <summary>
        /// Gets or sets the result code.
        /// </summary>
        /// <value>
        /// The result code.
        /// </value>
        public string resultCode { get; set; }

        /// <summary>
        /// Gets or sets the result description.
        /// </summary>
        /// <value>
        /// The result description.
        /// </value>
        public string resultDescription { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable<string> Errors { get; set; }
    }
}
