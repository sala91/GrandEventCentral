using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GrandEventCentral.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrandEventCentral.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public EventsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/<EventsController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<PublicEvent>> GetAsync()
        {
            var allPublicEvents = await context.PublicEvents.ToListAsync();
            return allPublicEvents;
        }

        // GET api/<EventsController>/5
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<PublicEvent> Get(Guid id)
        {
            var onePublicEvent = await context.PublicEvents.Where(x => x.Id == id).FirstOrDefaultAsync();
            return onePublicEvent;
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<Guid> PostAsync([FromBody] PublicEvent savableEvent)
        {
            savableEvent.CreatedAt = DateTime.UtcNow;
            savableEvent.Creator = (Microsoft.AspNetCore.Identity.IdentityUser)User.Identity;

            context.PublicEvents.Add(savableEvent);
            await context.SaveChangesAsync();
            return savableEvent.Id;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] PublicEvent incomingChange)
        {
            var existingPublicEvent = await context.PublicEvents.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPublicEvent == null) { return NotFound(); }

            context.Entry(existingPublicEvent).State = EntityState.Detached;
            existingPublicEvent = mapper.Map(incomingChange, existingPublicEvent);
            
            context.PublicEvents.Update(existingPublicEvent);
            await context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            var deletablePublicEvent = await context.PublicEvents.FindAsync(id);
            context.Remove(deletablePublicEvent);
            await context.SaveChangesAsync();
        }
    }
}
