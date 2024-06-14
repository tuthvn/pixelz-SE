using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Invoice
    {
        [Key]
        public Guid InvoiceId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}