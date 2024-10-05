using System.Text.Json.Serialization;

namespace Frontend.Models;

public class Set(int number)
{
    public int MatchRefId { get; set; }
    public int Number { get; set; } = number;
    public int TeamOneScore { get; set; }
    public int TeamTwoScore { get; set; }
    [JsonIgnore]
    public Match MatchNavigation { get; set; }
}