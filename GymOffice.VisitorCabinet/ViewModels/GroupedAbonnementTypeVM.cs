
using Newtonsoft.Json;
namespace GymOffice.VisitorCabinet.ViewModels
{
    public class GroupedAbonnementTypeVM
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("startVisitTime")]
        public string StartVisitTime { get; set; } = null!;
        [JsonProperty("endVisitTime")]
        public string EndVisitTime { get; set; } = null!;
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("pricesPerDurs")]
        public SortedDictionary<int, decimal> PricesPerDurs { get; set; } = new SortedDictionary<int, decimal>();
        [JsonIgnore]
        public List<decimal> Prices { get; set; } = null!;
        [JsonIgnore]
        public List<int> Durations { get; set; } = null!;
    }
}
