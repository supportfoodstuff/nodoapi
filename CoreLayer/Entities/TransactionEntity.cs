using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("transactions")]
    public class TransactionEntity
    {
        public int Id { get; set; }

        [Column("reference_code")]
        public string? ReferenceCode { get; set; }

        [Column("purchase_order_id")]
        public int? PurchaseOrderId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("transaction_type")]
        public string? TransactionType { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
