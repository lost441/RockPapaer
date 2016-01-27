
namespace Contracts.Response
{
    using System.Collections.Generic;

    public class ResponseList<T> : Result
    {
        public ResponseList()
        { }

        public ResponseList(ResultCodeEnum resultCode, string description = null)
            : base(resultCode, description)
        { }

        public IEnumerable<T> Data { get; set; }
    }
}
