using Microsoft.EntityFrameworkCore;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.Application.Activities;

public class List
{
   public class Query : IRequest<List<Activity>> { }

   public class Handler : IRequestHandler<Query, List<Activity>>
   {
      private readonly ApplicationDbContext _context;

      public Handler(ApplicationDbContext context)
      {
         _context = context;
      }

      public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
      {
         return await _context.Activities.ToListAsync();
      }
   }
}
