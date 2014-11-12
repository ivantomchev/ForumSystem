﻿namespace ForumSystem.Data.Models
{
    using ForumSystem.Data.Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class ApplicationUser : IdentityUser,IAuditInfo,IDeletableEntity
    {
        public ApplicationUser()
        {
            this.CreatedOn = DateTime.Now;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn{ get; set; }

        public bool IsDeleted{ get; set; }

        public DateTime? DeletedOn{ get; set; }

    }
}
