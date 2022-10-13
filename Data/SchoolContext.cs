using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api;

    public class SchoolContext : DbContext{
        
        public SchoolContext (DbContextOptions<SchoolContext> options): base(options){
        }

        public DbSet<api.Vak> Vak { get; set; } = default!;
    }
