using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("support_ticket_logs")]
    public class SupportTicketLogEntity
    {
        public int Id { get; set; }

        [Column("support_ticket_id")]
        public int SupportTicketId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("log_message")]
        public string? LogMessage { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
