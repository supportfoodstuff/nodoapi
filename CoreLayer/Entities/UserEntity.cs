using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("users")]
    public class UserEntity
    {
        public int Id { get; set; }

        [Column("full_name")]
        public string? FullName { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("password_hash")]
        public string? PasswordHash { get; set; }

        [Column("transaction_pin")]
        public string? TransactionPin { get; set; }
        
        [Column("available_balance")]
        public decimal AvailableBalance { get; set; }

        [Column("current_balance")]
        public decimal CurrentBalance { get; set; }

        [Column("credit_limit")]
        public decimal CreditLimit { get; set; }

        [Column("collateral_value")]
        public decimal CollateralValue { get; set; }

        [Column("role")]
        public string? Role { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
