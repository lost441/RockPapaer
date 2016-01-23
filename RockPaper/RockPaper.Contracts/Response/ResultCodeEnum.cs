
namespace RockPaper.Contracts.Response
{
    using System.ComponentModel;

    public enum ResultCodeEnum
    {
        [Description("NA")]
        Undefined,

        [Description("00")]
        Success,

        [Description("01")]
        NotFound,

        [Description("-1")]
        GeneralFailure
    }
}
