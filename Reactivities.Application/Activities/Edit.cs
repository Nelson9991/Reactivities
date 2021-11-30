using AutoMapper;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.Application.Activities;

public class Edit
{
   public class Command : IRequest
   {
      public Activity? Activity { get; set; }
   }

   public class Handler : IRequestHandler<Command>
   {
      private ApplicationDbContext _context;
      private readonly IMapper _mapper;

      public Handler(ApplicationDbContext context, IMapper mapper)
      {
         _context = context;
         _mapper = mapper;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
         var activity = await _context.Activities.FindAsync(request.Activity?.Id);

         if (activity is not null)
         {
            _mapper.Map(request.Activity, activity);
            await _context.SaveChangesAsync();
         }

         return Unit.Value;
      }
   }
}
