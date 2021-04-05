using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Universite.Models;

namespace Universite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<Universite.Models.Enseignant> Enseignant { get; set; }
        public DbSet<Universite.Models.Formation> Formation { get; set; }
        public DbSet<Universite.Models.UE> UE { get; set; }
        public DbSet<Universite.Models.Note> Note { get; set; }
        public DbSet<Universite.Models.Enseigner> Enseigner { get; set; }
    }
}
