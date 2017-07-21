using FluentValidator;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class OrderItem: Entity
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(i => i.Quantity, 0)
                .IsGreaterThan(i => i.Product.QuantityOnHand, quantity + 1, $"Não temos tantos {product.Title} em estoque.");

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}
