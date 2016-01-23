
namespace RockPaper.Contracts.Response
{
    public class ResponseItem<T> : Result
    {
        public ResponseItem()
        { }

        public ResponseItem(ResultCodeEnum resultCode, string description = null)
            : base(resultCode, description)
        { }

        public T Data { get; set; }
    }
}
