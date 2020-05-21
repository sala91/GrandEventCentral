using System;
using Microsoft.AspNetCore.Identity;

namespace GrandEventCentral.Shared.Entities
{
    public class Base
    {
        public Guid Id { get; set; }
        public virtual IdentityUser Creator { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
