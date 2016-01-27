
namespace RockPaper.Wpf.Common
{
    /// <summary>
    /// Operation outcome class.
    /// </summary>
    public class OperationOutcome
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OperationOutcome"/> is result.
        /// </summary>
        /// <value>
        ///   <c>true</c> if result; otherwise, <c>false</c>.
        /// </value>
        public bool Result { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public string Error { get; set; }
    }
}
