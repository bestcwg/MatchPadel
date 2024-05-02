using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DTO;

public class Match
{
    public int Id { get; set; }
    public int Winner { get; set; }
    [JsonPropertyName("DateTimeOffSet")]
    public long DateTimeOffset { get; set; }
    [ForeignKey("GameTypeRefId")]
    public GameType? GameType { get; set; } 
    [ForeignKey("MatchRefId")]
    public ICollection<Result>? Results { get; set; }
    [ForeignKey("MatchRefId")]
    public ICollection<Set>? Sets { get; set; }
}