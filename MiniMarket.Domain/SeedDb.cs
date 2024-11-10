using Bogus;
using MiniMarket.Domain.Context;
using MiniMarket.Domain.Entity;

namespace MiniMarket.Domain
{
    public class SeedDb
    {
        private readonly MiniMarketDbContext _context;
        public SeedDb(MiniMarketDbContext context)
        {
            this._context = context;
        }

        public void StartSeed()
        {
            // если есть продуеты то ничего не делаем
            if (!_context.Products.Any())
            {
                return;
            }

            // тут генерация продуктов и добавочных таблиц
            var product = GenerateProduct();
        }

        private IEnumerable<Product> GenerateProduct()
        {
            decimal minPrice = 0.1m;
            decimal maxPrice = 10000m;
            var fakeProduct = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.Product())
                .RuleFor(p => p.Price, f => Decimal.Parse(f.Commerce.Price(minPrice, maxPrice)))
                .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0]);

            var products= fakeProduct.Generate(100);
            return products;
        }
    }
}
