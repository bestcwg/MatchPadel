using System.Security.Cryptography.X509Certificates;
using Frontend.Models;
using Frontend.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Frontend.Data;

public class HttpClientService
{
    private MatchPadelContext db; 

    public HttpClientService(IConfiguration config) {
        var optionsBuilder = new DbContextOptionsBuilder<MatchPadelContext>();
        optionsBuilder.UseSqlite(config.GetConnectionString(nameof(MatchPadelContext)));
        db = new MatchPadelContext(optionsBuilder.Options);
    }

    public List<Match> GetMatches()
    {
        try
        {
            // var response = await _httpClient.GetFromJsonAsync<List<Match>>("/matches");
            // db.Matches;
            return db.Matches
                    .Include(m => m.GameType)
                    .Include(m => m.Sets)
                    .Include(m => m.Results)!
                    .ThenInclude(r => r.User)
                    .ToList();
            
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            return [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PostMatchAsync(Match match)
    {
        try
        {
            // var response = await _httpClient.PostAsJsonAsync("/match", match);
            foreach (var result in match.Results)
                {
                    var user = db.Users.FirstOrDefault(u => u.DisplayName == result.User.DisplayName);
                    if (user == null) continue;
                   
                    result.UserRefId = user.Id;
                    result.User = null;
                }
                await db.Matches.AddAsync(match);
                // Workaround so that ef dont try to add a new gametype to db
                db.Entry(match.GameType).State = EntityState.Unchanged;
               
                await db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        } 
    }
}