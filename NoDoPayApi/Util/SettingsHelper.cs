using CoreLayer.Entities;

namespace NoDoPayApi.Util
{
    public static class SettingsHelper
    {
        public static string GetValue(this List<SettingEntity> settings, string key)
        {
            return settings.FirstOrDefault(s => s.SettingKey == key)?.SettingValue ?? "";
        }

        public static List<SettingEntity> GetAllByCategory(this List<SettingEntity> settings, string category)
        {
            return settings.Where(s => s.SettingCategory == category).ToList();
        }

        public static List<SettingEntity> GetAllByEditable(this List<SettingEntity> settings)
        {
            return settings.Where(s => s.IsEditable == true).ToList();
        }

        public static SettingEntity GetSetting(this List<SettingEntity> settings, string key)
        {
            return settings.FirstOrDefault(s => s.SettingKey == key);
        }
    }
}
