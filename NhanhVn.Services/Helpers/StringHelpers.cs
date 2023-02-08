using System.Text;

namespace NhanhVn.Services.Helpers
{
    internal static class StringHelpers
    {
        public static string LowerFirstCharacter(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(value.Substring(0, 1).ToLower());
            stringBuilder.Append(value.Substring(1, value.Length - 1));
            return stringBuilder.ToString();
        }
    }
}