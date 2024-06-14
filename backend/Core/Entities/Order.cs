using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public string OrderName { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}