
namespace Contracts.Response
{
    using System.ComponentModel;

    public enum ResultCodeEnum
    {
        [Description("NA")]
        Undefined,

        [Description("00")]
        Success,
        
        [Description("-01")]
        GeneralFailure,

        [Description("-02")]
        NotFound,

        [Description("-03")]
        BadRequest,
        
        [Description("-04")]
        NotAuthorized,

        [Description("-05")]
        MethodNotAllowed
    }
}
