using Apple.Services.CouponAPI.Data;
using Apple.Services.CouponAPI.DTO;
using Apple.Services.CouponAPI.Repository.IRepository;
using AutoMapper;

namespace Apple.Services.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _db;
        protected IMapper _mapper;
        public CouponRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;   
            _mapper = mapper;
        }
        public async Task<CouponDto> GetCouponByCode(string code)
        {
            var couponFromDb = _db.Coupons.FirstOrDefault(x=>x.CouponCode == code);
            return _mapper.Map<CouponDto>(couponFromDb);
        }
    }
}
