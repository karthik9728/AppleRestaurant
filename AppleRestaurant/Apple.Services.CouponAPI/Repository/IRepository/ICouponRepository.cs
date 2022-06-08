using Apple.Services.CouponAPI.DTO;

namespace Apple.Services.CouponAPI.Repository.IRepository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode (string code);
    }
}
