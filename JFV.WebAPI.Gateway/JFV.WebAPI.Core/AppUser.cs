using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JFV.WebAPI.Gateway
{
    public class AppUser : IdentityUser, IModel
    {
        public string Id { get; set; }
    }
}
