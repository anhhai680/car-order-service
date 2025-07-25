using System;

namespace order_service
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CarId { get; set; } = string.Empty;
        public string BuyerId { get; set; } = string.Empty;
        public string Status { get; set; } = "pending"; // pending, paid, cancelled
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }
        public decimal Amount { get; set; }
    }
} 