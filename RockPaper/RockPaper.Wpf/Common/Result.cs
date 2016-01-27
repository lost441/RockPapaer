using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaper.Wpf.Common
{
    public class Result<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is successfull.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is successfull; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccessfull { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public string Errors { get; set; }
    }
}
