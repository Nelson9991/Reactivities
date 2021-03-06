using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.Application.Activities;

public class Details
{
   public class Query : IRequest<Activity?>
   {
      public Guid Id { get; set; }
   }

   public class Handler : IRequestHandler<Query, Activity?>
   {
      private readonly ApplicationDbContext _context;

      public Handler(ApplicationDbContext context)
      {
         _context = context;
      }

      public async Task<Activity?> Handle(Query request, CancellationToken cancellationToken)
      {
         return await _context.Activities.FindAsync(request.Id);
      }
   }
}
