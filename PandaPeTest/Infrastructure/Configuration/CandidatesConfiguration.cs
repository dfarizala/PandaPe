using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaPeTest.Api.Domain.Entities;

namespace PandaPeTest.Api.Infrastructure.Configuration
{
    public class CandidatesConfiguration : IEntityTypeConfiguration<Candidates>
    {
        public void Configure(EntityTypeBuilder<Candidates> builder)
        {
            builder.ToTable("Candidates", "dbo");
            builder.HasKey(x => x.IdCandidate);

            builder.Property(t => t.Name).HasMaxLength(50);
            builder.Property(t => t.SurName).HasMaxLength(150);
            builder.Property(t => t.Email).HasMaxLength(250);
        }
    }
}
