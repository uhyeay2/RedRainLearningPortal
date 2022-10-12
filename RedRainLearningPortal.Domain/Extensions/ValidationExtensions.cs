using System.Text.RegularExpressions;

namespace RedRainLearningPortal.Domain.Extensions
{
    public static class ValidationExtensions
    {
        public static bool IsValidEmailFormat(this string str) => str != null && new Regex(@".+@.+\..+").IsMatch(str);
    }
}
