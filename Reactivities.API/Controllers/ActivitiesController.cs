using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactivities.Domain;
using Reactivities.Persistence;

namespace Reactivities.API.Controllers;

public class ActivitiesController : BaseApiController
{
   private readonly ApplicationDbContext _context;

   public ActivitiesController(ApplicationDbContext context)
   {
      _context = context;
   }

   [HttpGet]
   public async Task<ActionResult<List<Activity>>> GetActivitiesAsync()
   {
      return await _context.Activities.ToListAsync();
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<Activity?>> GetActivityAsync(Guid id)
   {
      return await _context.Activities.FindAsync(id);
   }
}
