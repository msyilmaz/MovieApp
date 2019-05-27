using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.MvcUI.Entities
{
    public class CustomIdentityUser:IdentityUser<Guid>
    {
    }
}
