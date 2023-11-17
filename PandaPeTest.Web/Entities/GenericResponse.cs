using System.Net;

namespace PandaPeTest.Web.Entities
{
    public class GenericResponse
    {
        public string Message { get; set; }
        public HttpStatusCode HttpCode { get; set; }
        public object Data { get; set; }
    }
}
