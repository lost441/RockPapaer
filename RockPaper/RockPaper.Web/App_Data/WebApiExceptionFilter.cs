
namespace RockPaper.Web.App_Data
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using Contracts.Exceptions;
    using Contracts.Response;
    using Instrumentation.Logging;

    /// <summary>
    /// The Web API Exception Handler
    /// </summary>
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// The _logger
        /// </summary>
        private Logging logger = LogFactory.Create();

        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var matched = false;
            var resultCode = ResultCodeEnum.Undefined;
            var errorDescription = string.Empty;

            var errorToken = logger.ErrorWithRef(context.Exception.Message);
            
            if (context.Exception is UnAuthorizedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                resultCode = ResultCodeEnum.NotAuthorized;
                errorDescription = string.Format("Not authorized to access resource. ref [{0}]", errorToken);

                matched = true;
            }

            if (context.Exception is BadRequestException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                resultCode = ResultCodeEnum.BadRequest;
                errorDescription = string.Format("Bad Request. ref = [{0}]", errorToken);

                matched = true;
            }

            if (context.Exception is NotFoundException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
                resultCode = ResultCodeEnum.NotFound;
                errorDescription = string.Format("Not found. ref = [{0}]", errorToken);

                matched = true;
            }

            if (context.Exception is MethodNotAllowedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
                resultCode = ResultCodeEnum.MethodNotAllowed;
                errorDescription = string.Format("Method not allowed. ref = [{0}]", errorToken);

                matched = true;
            }

            if (!matched)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                resultCode = ResultCodeEnum.GeneralFailure;
                errorDescription = string.Format("Internal server exception. ref [{0}]", errorToken);
            }
            
            var response = new ResponseItem<bool>(resultCode)
            {
                ResultDescription = errorDescription
            };

            var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(response);

            context.Response.Content = new StringContent(json);
        }
    }
}