using System.Text.Json;

namespace NhanhVn.Services.Helpers
{
    public class JsonHelpers
    {
        private static JsonElement GetPropertyByKeyPath(JsonElement node, string keyPath)
        {
            var currentNode = node;
            if(keyPath is null)
            {
                return currentNode;
            }
            var keys = keyPath.Split('.');

            foreach (var key in keys)
            {
                if (currentNode.TryGetProperty(key, out var property))
                {
                    currentNode = property;
                }
                else
                {
                    return default;
                }
            }

            return currentNode;
        }

        public static T DeserializeByPath<T>(string jsonString, string keyPath, JsonSerializerOptions? options = null)
            where T : class
        {
            using JsonDocument document = JsonDocument.Parse(jsonString);

            JsonElement element = GetPropertyByKeyPath(document.RootElement, keyPath);
            return element.Deserialize<T>(options);
        }
    }
}
