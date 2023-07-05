using MelonMVCBookshelf.Models;
using MelonMVCBookshelf.Models.Enums;
using MelonMVCBookshelf.Models.Requests;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MelonMVCBookshelf.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Requests> BookRequests { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<WantedResources> WantedResources { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
