using DTO;
using Frontend.Enum;

namespace Frontend.Data;

public class Matches
{
    public Dictionary<int, Dictionary<Teams,List<User>>> Data { get; set; } = new();
}