using Apple.Services.ShoppingCartAPI.Data;
using Apple.Services.ShoppingCartAPI.DTO;
using Apple.Services.ShoppingCartAPI.Model;
using Apple.Services.ShoppingCartAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Apple.Services.ShoppingCartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CartRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }



        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {

            Cart cart = _mapper.Map<Cart>(cartDto);

            //check if product exists in database, if not create it!
            var prodInDb = await _db.Products
                .FirstOrDefaultAsync(u => u.ProductId == cartDto.CardDetails.FirstOrDefault()
                .ProductId);
            if (prodInDb == null)
            {
                _db.Products.Add(cart.CardDetails.FirstOrDefault().Product);
                await _db.SaveChangesAsync();
            }


            //check if header is null
            var cartHeaderFromDb = await _db.CartHeaders.AsNoTracking()
                .FirstOrDefaultAsync(u => u.userId == cart.CardHeader.userId);

            if (cartHeaderFromDb == null)
            {
                //create header and details
                _db.CartHeaders.Add(cart.CardHeader);
                await _db.SaveChangesAsync();
                cart.CardDetails.FirstOrDefault().CardHeaderId = cart.CardHeader.CardHeaderId;
                cart.CardDetails.FirstOrDefault().Product = null;
                _db.CartDetails.Add(cart.CardDetails.FirstOrDefault());
                await _db.SaveChangesAsync();
            }
            else
            {
                //if header is not null
                //check if details has same product
                var cartDetailsFromDb = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    u => u.ProductId == cart.CardDetails.FirstOrDefault().ProductId &&
                    u.CardHeaderId == cartHeaderFromDb.CardHeaderId);

                if (cartDetailsFromDb == null)
                {
                    //create details
                    cart.CardDetails.FirstOrDefault().CardHeaderId = cartHeaderFromDb.CardHeaderId;
                    cart.CardDetails.FirstOrDefault().Product = null;
                    _db.CartDetails.Add(cart.CardDetails.FirstOrDefault());
                    await _db.SaveChangesAsync();
                }
                else
                {
                    //update the count / cart details
                    cart.CardDetails.FirstOrDefault().Product = null;
                    cart.CardDetails.FirstOrDefault().Count += cartDetailsFromDb.Count;
                    _db.CartDetails.Update(cart.CardDetails.FirstOrDefault());
                    await _db.SaveChangesAsync();
                }
            }

            return _mapper.Map<CartDto>(cart);

        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CardHeader = await _db.CartHeaders.FirstOrDefaultAsync(u => u.userId == userId)
            };

            cart.CardDetails = _db.CartDetails
                .Where(u => u.CardHeaderId == cart.CardHeader.CardHeaderId).Include(u => u.Product);

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            try
            {
                CardDetails cartDetails = await _db.CartDetails
                    .FirstOrDefaultAsync(u => u.CardDeatilsId == cartDetailsId);

                int totalCountOfCartItems = _db.CartDetails
                    .Where(u => u.CardHeaderId == cartDetails.CardHeaderId).Count();

                _db.CartDetails.Remove(cartDetails);
                if (totalCountOfCartItems == 1)
                {
                    var cartHeaderToRemove = await _db.CartHeaders
                        .FirstOrDefaultAsync(u => u.CardHeaderId == cartDetails.CardHeaderId);

                    _db.CartHeaders.Remove(cartHeaderToRemove);
                }
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}