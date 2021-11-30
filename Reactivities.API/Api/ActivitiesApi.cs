using Reactivities.Application.Activities;
using Reactivities.Domain;

namespace Reactivities.API.Api;

public static class ActivitiesApi
{
   public static void ConfigureActivitiesApi(this WebApplication app)
   {
      app.MapGet("/activities", GetActivities);
      app.MapGet("/activities/{id}", GetActivity);
      app.MapPost("/activities", InsertActivity);
      app.MapPut("/activities/{id}", EditActivity);
      app.MapDelete("/activities/{id}", DeleteActivity);
   }

   private static async Task<IResult> GetActivities(IMediator mediator)
   {
      return Results.Ok(await mediator.Send(new List.Query()));
   }

   private static async Task<IResult> GetActivity(IMediator mediator, Guid id)
   {
      return Results.Ok(await mediator.Send(new Details.Query { Id = id }));
   }

   private static async Task<IResult> InsertActivity(IMediator mediator,
      Activity activity)
   {
      return Results.Ok(await mediator.Send(new Create.Command { Activity = activity }));
   }

   private static async Task<IResult> EditActivity(IMediator mediator, Guid id,
      Activity activity)
   {
      activity.Id = id;
      return Results.Ok(await mediator.Send(new Edit.Command { Activity = activity }));
   }

   private static async Task<IResult> DeleteActivity(IMediator mediator, Guid id)
   {
      return Results.Ok(await mediator.Send(new Delete.Command { Id = id }));
   }
}
