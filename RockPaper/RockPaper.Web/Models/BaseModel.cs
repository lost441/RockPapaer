
namespace RockPaper.Web.Models
{
    using App_Data;

    /// <summary>
    /// THe Base Model
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModel"/> class.
        /// </summary>
        public BaseModel()
        {
            this.BaseUrl = WebWorker.GetBaseUrl();
        }

        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>The website base URL</value>
        public string BaseUrl { get; set; }
    }
}