using Newtonsoft.Json;

namespace Concessonaria.Models.UI
{
    public class ApiSettings
    {
        [JsonProperty("SqlServerConnectionString")]
        public string SqlServerConnectionString { get; set; }
    }
}
