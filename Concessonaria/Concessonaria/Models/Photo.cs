using Newtonsoft.Json;
using System.Buffers.Text;

namespace Concessonaria.Models
{
    public class Photo
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("base64")]
        public string base64 { get; set; }
    }
}
