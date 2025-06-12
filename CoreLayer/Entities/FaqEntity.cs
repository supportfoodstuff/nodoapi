using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    [Table("FAQ")]
    public class FaqEntity
    {
        public int Id { get; set; }

        [Column("question")]
        public string? question { get; set; }

        [Column("answer")]
        public string? answer { get; set; }

        [Column("is_published")]
        public bool? published { get; set; }
        
        [Column("category")]
        public string? category { get; set; }

        [Column("created_at")]
        public DateTime? created_on { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? updated_on { get; set; } = DateTime.UtcNow;
    }
}
