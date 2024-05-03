using DTO;
using Frontend.Enum;

namespace Frontend.Data;

public class Matches
{
    public Dictionary<int, DTO.Match> Data { get; set; } = new();
}