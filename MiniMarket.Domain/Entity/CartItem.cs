namespace MiniMarket.Domain.Entity
{
    public class CartItem:BaseEntity
    {
        public int CartId { get; set; }  // ID корзины, к которой привязан товар
        public Cart Cart { get; set; }   // Навигационное свойство для связи с Cart

        public int ProductId { get; set; }  // ID товара
        public Product Product { get; set; } // Навигационное свойство для связи с Product

        public int Quantity { get; set; }  // Количество товара
    }

}