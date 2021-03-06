﻿using GrandEventCentral.Shared.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GrandEventCentral.Server
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        public DbSet<PublicEvent> PublicEvents { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
