
namespace RockPaper.Web
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using Contracts.Exceptions;

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

            if (context.Exception is UnAuthorizedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                matched = true;
            }

            if (context.Exception is BadRequestException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                matched = true;
            }

            if (context.Exception is NotFoundException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
                matched = true;
            }

            if (!matched)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}