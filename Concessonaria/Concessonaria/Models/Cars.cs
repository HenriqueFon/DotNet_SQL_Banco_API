using Newtonsoft.Json;

namespace Concessonaria.Models
{
    public class Cars
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("PhotoId")]
        public int PhotoId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

    }
}
