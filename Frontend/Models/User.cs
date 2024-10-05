using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Frontend.Models;

public class User 
{
    public int Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    [ForeignKey("UserRefId")]
    [JsonIgnore]
    public ICollection<Result> Results { get; set; }
}