using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    [Table("settings")]
    public class SettingEntity
    {
        public int Id { get; set; }

        [Column("setting_name")]
        public string? SettingName { get; set; }

        [Column("setting_key")]
        public string? SettingKey { get; set; }

        [Column("setting_value")]
        public string? SettingValue { get; set; }

        [Column("setting_description")]
        public string? SettingDescription { get; set; }

        [Column("setting_datatype")]
        public string? SettingDataType { get; set; }

        [Column("setting_category")]
        public string? SettingCategory { get; set; }

        [Column("is_editable")]
        public bool? IsEditable { get; set; } = true;

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
