using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace GrandEventCentral.Server.Entities
{
    public class Base
    {
        public Guid Id { get; set; }
        public virtual IdentityUser Creator { get; set; }
    }
}
