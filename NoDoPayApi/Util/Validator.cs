namespace NoDoPayApi.Util
{
    public class Validator
    {
        public static decimal TryParseDecimal(string? value)
        {
            return decimal.TryParse(value, out var result) ? result : 0;
        }
    }
}
