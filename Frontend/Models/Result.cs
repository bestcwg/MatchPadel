using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Frontend.Models;

public class Result
{
    public int UserRefId { get; set; }
    public int Team { get; set; }
    public int MatchRefId { get; set; }
    public int Score { get; set; }
    [JsonIgnore]
    public Match Match { get; set; }
    public User? User { get; set; }
}