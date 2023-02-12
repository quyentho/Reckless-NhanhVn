
using System.Text.Json.Serialization;

namespace NhanhVn.Common.Models
{
    public class NhanhProductInventory
    {
        // care
        [JsonPropertyName("remain")]
        public int remain { get; set; }
        public int shipping { get; set; }
        public int damaged { get; set; }
        public int holding { get; set; }
        // care
        public int available { get; set; }

        [JsonIgnore]
        public Dictionary<string,NhanhProductInventory> depots { get; set; }
    }
}
