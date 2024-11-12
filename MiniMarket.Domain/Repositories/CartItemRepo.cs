using MiniMarket.Domain.Context;
using MiniMarket.Domain.Entity;
using MiniMarket.Domain.Repositories.Contract;

namespace MiniMarket.Domain.Repositories
{
    public class CartItemRepo : GenericRepo<CartItem>, ICartItemRepo
    {
        public CartItemRepo(MiniMarketDbContext context) : base(context) { }
      
    }
}
