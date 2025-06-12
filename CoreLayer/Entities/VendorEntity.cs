using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("vendors")]
    public class VendorEntity
    {
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("bank_account_no")]
        public string? BankAccountNo { get; set; }

        [Column("bank_name")]
        public string? BankName { get; set; }

        [Column("total_paid_po")]
        public int TotalPaidPO { get; set; }

        [Column("total_owing_po")]
        public int TotalOwingPO { get; set; }

        [Column("sum_of_paid_po")]
        public decimal SumOfPaidPO { get; set; }

        [Column("sum_of_pending_po")]
        public decimal SumOfPendingPO { get; set; }
        
        [Column("is_verified")]
        public bool IsVerified { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
