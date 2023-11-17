using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PandaPeTest.Api.Domain.Entities;

namespace PandaPeTest.Api.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Candidates> ComentarioObraNueva => Set<Candidates>();
        public DbSet<CandidateExperiences> ComentarioSolicitud => Set<CandidateExperiences>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
