namespace MiniMarket.Domain.Entity
{
    public class Cart:BaseEntity
    {
        public int UserId { get; set; } // ID пользователя, к которому привязана корзина
        public User User { get; set; }  // Навигационное свойство для связи с User

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>(); // Список товаров в корзине
    }

}
