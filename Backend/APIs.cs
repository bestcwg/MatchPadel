using Backend.Context;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace Backend;

using Db = MatchPadelContext;

public static class APIs
{
    public static void AddEFEndpoints(WebApplication app)
    {
        app.MapGet("/gametypes", (Db db) =>
            {
                var gametypes = db.GameTypes;
                return gametypes;
            })
            .WithName("GetGameTypes")
            .WithOpenApi();
      
        AddMatchesEndpoints(app);
    }

    private static void AddMatchesEndpoints(WebApplication app)
    {
        app.MapGet("/matches", (Db db) =>
            {
                var matches = db.Matches
                    .Include(m => m.GameType)
                    .Include(m => m.Sets)
                    .Include(m => m.Results)!
                    .ThenInclude(r => r.User);
                return matches;
            })
            .WithName("GetMatches")
            .WithOpenApi();

        app.MapPost("/match", async (Match match, Db db) =>
            {
               
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
            })
            .WithName("PostMatch")
            .WithOpenApi();
    }
}