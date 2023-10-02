using System.Net;

namespace Magic_Villa_7.Modelos
{
    public class ApiResponse
    {
        public HttpStatusCode statusCode { get; set; }

        public bool IsExitoso { get; set; } = true;

        public List<string> ErrorMessages { get; set; }

        public object Resultado { get; set; }
    }
}
