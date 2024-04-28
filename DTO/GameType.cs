namespace DTO;

public class GameType
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ICollection<Match> Matches { get; set; }
}