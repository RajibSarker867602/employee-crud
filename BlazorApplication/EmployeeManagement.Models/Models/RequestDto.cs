namespace EmployeeManagement.Models
{
    public enum APIType
    {
        GET = 1,
        POST = 2,
        PUT = 3,
        DELETE = 4,
    }

    public enum AppContentType
    {
        Json,
        MultiPartFormData
    }

    public class RequestDto
    {
        public APIType APIType { get; set; } = APIType.GET;
        public string Url { get; set; }
        public object? Data { get; set; }
        public string AccessToken { get; set; }

        public AppContentType ContentType { get; set; } = AppContentType.Json;

    }
}
