
namespace Contracts.Response
{
    public static class SuccessMapper
    {
        public static bool GetSuccess(this ResultCodeEnum original)
        {
            switch (original)
            {
                case ResultCodeEnum.Success:
                    return true;
                default: return false;
            }
        }
    }
}
