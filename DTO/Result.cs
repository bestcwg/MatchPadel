using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO;

public class Result
{
    public int PlayerId { get; set; }
    public int Score { get; set; }
    public int MatchRefId { get; set; }
    public Match Match { get; set; }
}