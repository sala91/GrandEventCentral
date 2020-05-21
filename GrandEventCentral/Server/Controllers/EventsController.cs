using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GrandEventCentral.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GrandEventCentral.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EventsController(ApplicationDbContext context, 
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: api/<EventsController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<PublicEvent>> GetAsync()
        {
            var allPublicEvents = await _context.PublicEvents.ToListAsync();
            return allPublicEvents;
        }

        // GET api/<EventsController>/5
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<PublicEvent> Get(Guid id)
        {
            var onePublicEvent = await _context.PublicEvents.Where(x => x.Id == id).FirstOrDefaultAsync();
            return onePublicEvent;
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<Guid> PostAsync([FromBody] PublicEvent savableEvent)
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);

            savableEvent.CreatedAt = DateTime.UtcNow;
            savableEvent.Creator = user;

            _context.PublicEvents.Add(savableEvent);
            await _context.SaveChangesAsync();
            return savableEvent.Id;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] PublicEvent incomingChange)
        {
            var existingPublicEvent = await _context.PublicEvents.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPublicEvent == null) { return NotFound(); }

            _context.Entry(existingPublicEvent).State = EntityState.Detached;
            existingPublicEvent = _mapper.Map(incomingChange, existingPublicEvent);
            
            _context.PublicEvents.Update(existingPublicEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            var deletablePublicEvent = await _context.PublicEvents.FindAsync(id);
            _context.Remove(deletablePublicEvent);
            await _context.SaveChangesAsync();
        }
    }
}
