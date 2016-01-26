
namespace RockPaper.Web.Areas.V01
{
    using System.Web.Mvc;

    /// <summary>
    /// V01 Registration
    /// </summary>
    public class V01AreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "V01";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
           // Use Attribute Routing on Controller
        }
    }
}