using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("po_activity_log")]
    public class PoActivityLogEntity
    {
        public int Id { get; set; }

        [Column("purchase_order_id")]
        public int PurchaseOrderId { get; set; }

        [Column("activity_type")]
        public string? ActivityType { get; set; } // Optionally use an enum

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
