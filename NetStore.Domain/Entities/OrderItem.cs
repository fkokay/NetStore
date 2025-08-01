using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public decimal TotalPrice => UnitPrice * Quantity;

        public OrderItem()
        {

        }
        public OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void IncreaseQuantity(int amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive");
            Quantity += amount;
        }

        public void DecreaseQuantity(int amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive");
            if (Quantity - amount < 0) throw new InvalidOperationException("Quantity cannot be negative");
            Quantity -= amount;
        }
    }
}