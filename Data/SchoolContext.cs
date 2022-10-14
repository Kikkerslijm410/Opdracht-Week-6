using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using api;

    public class SchoolContext : IdentityDbContext{
        
        public SchoolContext (DbContextOptions<SchoolContext> options): base(options){
        }

        public DbSet<api.Vak> Vak { get; set; } = default!;
    }
