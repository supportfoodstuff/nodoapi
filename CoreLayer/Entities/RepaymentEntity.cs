using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("repayments")]
    public class RepaymentEntity
    {
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        
        [Column("user_business_name")]
        public string UserBusinessName { get; set; }

        [Column("vendor_id")]
        public int VendorId { get; set; }

        [Column("purchase_order_id")]
        public int PurchaseOrderId { get; set; }

        [Column("total_po_value")]
        public decimal TotalPoValue { get; set; }

        [Column("amount_repaid")]
        public decimal AmountRepaid { get; set; }

        [Column("due_date")]
        public DateTime? DueDate { get; set; }

        [Column("status")]
        public string? Status { get; set; } // ENUM: 'Paid', 'On Time', 'Overdue'

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
