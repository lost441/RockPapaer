
using System.Net.Http.Headers;

namespace RockPaper.Web
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using Contracts.Exceptions;
    using Contracts.Response;

    /// <summary>
    /// The Web API Exception Handler
    /// </summary>
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var matched = false;
            var resultCode = ResultCodeEnum.Undefined;
            var errorDescription = string.Empty;
            
            if (context.Exception is UnAuthorizedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                resultCode = ResultCodeEnum.NotAuthorized;
                errorDescription = "Not authorized to access resource";

                matched = true;
            }

            if (context.Exception is BadRequestException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                resultCode = ResultCodeEnum.BadRequest;
                errorDescription = "Bad Request";

                matched = true;
            }

            if (context.Exception is NotFoundException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
                resultCode = ResultCodeEnum.NotFound;
                errorDescription = "Not found";

                matched = true;
            }

            if (!matched)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                resultCode = ResultCodeEnum.GeneralFailure;
                errorDescription = "Internal server exception";
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