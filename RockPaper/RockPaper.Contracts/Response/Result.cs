
namespace RockPaper.Contracts.Response
{
    using System.Collections.Generic;

    public class Result
    {
        public Result()
        {
            Errors = new List<string>();
        }

        public Result(ResultCodeEnum resultCode, string description = null)
            : this()
        {
            this.IsSuccessfull = resultCode.GetSuccess();
            this.ResultCode = resultCode.ToString();
            this.ResultDescription = description;
        }

        public bool IsSuccessfull { get; set; }

        public string ResultCode { get; set; }

        public string ResultDescription { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
