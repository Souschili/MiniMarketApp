namespace MiniMarket.Domain.Entity
{
    public class User:BaseEntity
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
    }
}
