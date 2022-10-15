using System.Text.RegularExpressions;

namespace RedRainLearningPortal.Domain.Extensions
{
    public static class ValidationExtensions
    {
        public static bool IsValidEmailFormat(this string str) => !string.IsNullOrWhiteSpace(str) && new Regex(@".+@.+\..+").IsMatch(str);

        public static bool StringsAreNotNullOrWhiteSpace(this bool isValid, out List<string> validationErrors, params (string Value, string Name)[] requiredStringAndPropertyNames)
        {
            validationErrors = requiredStringAndPropertyNames.Select(x => string.IsNullOrWhiteSpace(x.Value) ?  $"{x.Name} is a required field!" : string.Empty)
                    .Where(x => x != string.Empty).ToList();

            return !validationErrors.Any() && isValid;
        }
    }
}
