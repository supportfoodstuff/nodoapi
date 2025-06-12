using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("purchase_orders")]
    public class PurchaseOrderEntity
    {
        public int Id { get; set; }

        [Column("po_code")]
        public string? PoCode { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("vendor_id")]
        public int VendorId { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }
        
        [Column("amount_owed_by_customer")]
        public decimal AmountOwedByCustomer { get; set; }

        [Column("status")]
        public string? Status { get; set; } // Consider using an enum if needed

        [Column("payment_date")]
        public DateTime? PaymentDate { get; set; }
        
        [Column("repayment_due_date")]
        public DateTime? RePaymentDueDate { get; set; }

        [Column("internal_notes")]
        public string? InternalNotes { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
