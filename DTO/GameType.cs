using System.Text.Json.Serialization;

namespace DTO;

public class GameType
{
    public int Id { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public ICollection<Match> Matches { get; set; }
}