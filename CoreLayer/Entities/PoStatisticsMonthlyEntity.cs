using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("po_statistics_monthly")]
    public class PoStatisticsMonthlyEntity
    {
        public int Id { get; set; }

        [Column("month")]
        public string? Month { get; set; }

        [Column("total_po_value")]
        public decimal TotalPoValue { get; set; }

        [Column("no_of_pos")]
        public int NumberOfPOs { get; set; }

        [Column("top_vendor_id")]
        public int TopVendorId { get; set; }
    }
}
