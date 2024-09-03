using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto, bool withToken = true);
    }
}
