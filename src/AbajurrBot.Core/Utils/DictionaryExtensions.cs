using AbajurrBot.Core.Models;

namespace AbajurrBot.Core.Utils
{
    public static class DictionaryExtensions
    {
        public static string AsString(this Dictionary<string, Channel> source)
        {
            var channels = string.Empty;

            foreach (var kvp in source)
            {
                channels += $"\n- {kvp.Value}";
            }

            return channels;
        }
    }
}
