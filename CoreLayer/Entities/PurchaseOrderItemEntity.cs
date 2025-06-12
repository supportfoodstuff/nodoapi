using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("purchase_order_items")]
    public class PurchaseOrderItemEntity
    {
        public int Id { get; set; }

        [Column("purchase_order_id")]
        public int PurchaseOrderId { get; set; }

        [Column("unit_of_measure")]
        public string UnitOfMeasure { get; set; }
        
        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unit_price")]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
