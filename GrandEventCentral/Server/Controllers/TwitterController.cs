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
using Tweetinvi;

namespace GrandEventCentral.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TwitterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TwitterController(ApplicationDbContext context, 
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
        public async void HelloWorld()
        {
            // Set up your credentials (https://apps.twitter.com)
            Auth.SetUserCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");

            // Publish the Tweet "Hello World" on your Timeline
            Tweet.PublishTweet("Hello World!");
        }
    }
}
