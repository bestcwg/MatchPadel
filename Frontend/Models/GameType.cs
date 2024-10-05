using System.Text.Json.Serialization;

namespace Frontend.Models;

public class GameType
{
    public int Id { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public ICollection<Match> Matches { get; set; }
}