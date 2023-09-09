using System.Net;

namespace SpecialTask.Application.Exceptions
{
    public class TooManyRequestException : ClientException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;
        public override string TitleMessage { get; protected set; } = string.Empty;
    }
}
