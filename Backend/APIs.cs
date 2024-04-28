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
                   .Include(m => m.Results);
               return matches;
           })
           .WithName("GetMatches")
           .WithOpenApi();

       app.MapPost("/match", async (Match match, Db db) =>
           {
               await db.Matches.AddAsync(match);
               // Workaround so that ef dont try to add a new gametype to db
               db.Entry(match.GameType).State = EntityState.Unchanged;
               
               await db.SaveChangesAsync();
           })
           .WithName("PostMatch")
           .WithOpenApi();
   }
}