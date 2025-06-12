using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("products")]
    public class ProductEntity
    {
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        
        [Column("name")]
        public string? Name { get; set; }

        [Column("sku")]
        public string? Sku { get; set; } = "N/A";

        [Column("unit_price")]
        public decimal UnitPrice { get; set; }

        [Column("unit_of_measure")]
        public string? UnitOfMeasure { get; set; }

        [Column("is_active")]
        public bool? IsActive { get; set; } = true;

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
