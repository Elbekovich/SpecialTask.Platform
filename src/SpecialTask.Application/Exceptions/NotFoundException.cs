using System.Net;

namespace SpecialTask.Application.Exceptions
{
    public class NotFoundException : ClientException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
        public override string TitleMessage { get; protected set; } = string.Empty;
    }
}
