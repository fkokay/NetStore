using NetStore.Domain.Common;
using NetStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int OrderChannelId { get; set; }
        public OrderChannel Channel { get; set; }
        public Guid CustomerId { get; set; }  // Müşteri Id (gerekirse Customer entity referansı eklenebilir)
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order(Guid customerId)
        {
            CustomerId = customerId;
            OrderDate = DateTime.UtcNow;
            Status = OrderStatus.Pending;
        }

        public Order()
        {

        }

        public void AddItem(Product product, int quantity, decimal unitPrice)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.IncreaseQuantity(quantity);
            }
            else
            {
                Items.Add(new OrderItem(product.Id, quantity, unitPrice));
            }
            RecalculateTotal();
        }

        public void RecalculateTotal()
        {
            TotalAmount = Items.Sum(i => i.TotalPrice);
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }
}