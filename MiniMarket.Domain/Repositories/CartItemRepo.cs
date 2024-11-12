using MiniMarket.Domain.Context;
using MiniMarket.Domain.Entity;
using MiniMarket.Domain.Repositories.Contract;

namespace MiniMarket.Domain.Repositories
{
    internal class CartItemRepo : GenericRepo<CartItem>, ICartItem
    {
        public CartItemRepo(MiniMarketDbContext context) : base(context) { }
      
    }
}
