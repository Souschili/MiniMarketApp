using MiniMarket.Domain.Context;
using MiniMarket.Domain.Entity;
using MiniMarket.Domain.Repositories.Contract;

namespace MiniMarket.Domain.Repositories
{
    internal class CartRepo : GenericRepo<Cart>, ICartRepo
    {
        public CartRepo(MiniMarketDbContext context) : base(context) { }
        
    }
}
