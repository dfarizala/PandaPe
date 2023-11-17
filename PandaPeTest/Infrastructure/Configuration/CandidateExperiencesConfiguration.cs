using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaPeTest.Api.Domain.Entities;

namespace PandaPeTest.Api.Infrastructure.Configuration
{
    public class CandidateExperiencesConfiguration : IEntityTypeConfiguration<CandidateExperiences>
    {
        public void Configure(EntityTypeBuilder<CandidateExperiences> builder)
        {
            builder.ToTable("CandidateExperiences", "dbo");
            builder.HasKey(x => x.IdCandidateExperience);

            builder.Property(t => t.Company).HasMaxLength(100);
            builder.Property(t => t.Job).HasMaxLength(100);
            builder.Property(t => t.Description).HasMaxLength(4000);

            builder.HasOne(t => t.Candidates)
            .WithMany(t => t.CandidatesExperiences)
            .HasForeignKey(t => t.IdCandidate)
            .HasConstraintName("FK_CandidatesExperiences_Candidates");

        }
    }
}
