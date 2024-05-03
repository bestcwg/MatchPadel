using DTO;
using Frontend.Enum;

namespace Frontend.Data;

public class Matches
{
    public Dictionary<int, DTO.Match> Data { get; set; } = new();

    public int AddMatch(Match match)
    {
        var random = new Random();
        var id = random.Next();
        Data.Add(id, match);
        return id;
    }

    public Match GetMatch(int key)
    {
        Data.TryGetValue(key, out var match);
        if (match == null) throw new Exception("Could not get match with key: " + key);
        return match;
    }
}