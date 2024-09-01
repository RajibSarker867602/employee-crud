using System.Net;
using System.Net.Mime;
using System.Security.AccessControl;
using System.Text;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Newtonsoft.Json;


namespace EmployeeManagement.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto> SendAsync(RequestDto requestDto, bool withToken = true)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("EmployeeManagementSystemAPI");
                HttpRequestMessage message = new();

                if (requestDto.ContentType == AppContentType.MultiPartFormData)
                {
                    message.Headers.Add("Accept", "*/*");
                }
                else
                {
                    message.Headers.Add("Accept", "application/json");
                }

                // set token
                if (withToken)
                {
                    //var token = _tokenProvider.GetToken();
                    //message.Headers.Add("Authorization", $"Bearer {token}");
                }

                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.ContentType == AppContentType.MultiPartFormData)
                {
                    var content = new MultipartFormDataContent();

                    foreach (var prop in requestDto.Data.GetType().GetProperties())
                    {
                        var value = prop.GetValue(requestDto.Data);
                        if (value is FormFile)
                        {
                            var file = (FormFile)value;
                            if (file != null)
                            {
                                content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                            }
                        }
                        else
                        {
                            content.Add(new StringContent(value == null ? "" : value.ToString()), prop.Name);
                        }
                    }
                    message.Content = content;
                }
                else
                {
                    if (requestDto.Data != null)
                    {
                        message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8,
                            "application/json");
                    }
                }


                HttpResponseMessage? apiResponse = null;
                switch (requestDto.APIType)
                {
                    case APIType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case APIType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case APIType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);
                var responseContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(responseContent);
                switch (apiResponse.StatusCode)
                {

                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not found!" };
                    case HttpStatusCode.Unauthorized:
                        return new()
                        {
                            IsSuccess = false,
                            Message = apiResponseDto != null && !string.IsNullOrEmpty(apiResponseDto.Message) ?
                                apiResponseDto.Message : "You're not authorized to access this request!"
                        };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Sorry! this request is forbidden." };
                    case HttpStatusCode.BadRequest:
                        return new() { IsSuccess = false, Message = "Invalid input request!" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal server error!" };
                    default:
                        return apiResponseDto;
                }
            }
            catch (Exception e)
            {
                return new() { IsSuccess = false, Message = e.Message.ToString() };
            }
        }
    }
}
