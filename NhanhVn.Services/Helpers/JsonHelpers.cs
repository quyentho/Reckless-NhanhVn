using System.Text.Json;
using System.Text.Json.Nodes;

namespace NhanhVn.Services.Helpers
{
    public class JsonHelpers
    {

        private static JsonElement GetPropertyByKeyPath(JsonElement node, string keyPath)
        {
            var currentNode = node;
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

        public static T DeserializeFromCamalCaseContent<T>(string jsonString, string keyPath)
        {
            using JsonDocument document = JsonDocument.Parse(jsonString);

            JsonElement studentsElement = GetPropertyByKeyPath(document.RootElement, keyPath);
            return studentsElement.Deserialize<T>(
                options: new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                }
            );
        }
    }
}
