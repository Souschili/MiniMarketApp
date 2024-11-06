namespace MiniMarket.Domain.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Category { get; set; } = string.Empty;
    }
}
