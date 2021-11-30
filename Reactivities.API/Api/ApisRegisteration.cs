namespace Reactivities.API.Api;

public static class ApisRegisteration
{
   public static void RegisterApis(this WebApplication app)
   {
      app.ConfigureActivitiesApi();
   }
}
