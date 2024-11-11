using MiniMarket.Domain.Context;
using MiniMarket.Domain.Entity;
using MiniMarket.Domain.Repositories.Contract;

namespace MiniMarket.Domain.Repositories
{
    internal class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(MiniMarketDbContext context) : base(context) { }

    }
}
