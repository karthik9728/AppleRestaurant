using Apple.Web.DTO.AppleServicesProductAPI.Response;
using Apple.Web.Models.ApiRequest;

namespace Apple.Web.Services.IServices
{
    public interface IBaseService :IDisposable
    {
        ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
