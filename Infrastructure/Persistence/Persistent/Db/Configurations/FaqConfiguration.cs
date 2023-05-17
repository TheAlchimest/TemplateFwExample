
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateFwExample.Domain.Models;

namespace TemplateFwExample.Persistence.Persistent.Db.Configures
{

    internal class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> entity)
        {
            entity.ToTable("Faq");

            entity.HasIndex(e => e.PortalId, "IX_FAQ_PortalId");

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.QuestionAr)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.QuestionEn)
               .IsRequired()
               .HasMaxLength(500);
            entity.Property(e => e.AnswerAr)
               .IsRequired()
               .HasMaxLength(2000);
            entity.Property(e => e.AnswerEn)
               .IsRequired()
               .HasMaxLength(2000);
        }
    }




    internal class VwFaqFullDetailConfiguration : IEntityTypeConfiguration<VwFaq>
    {
        public void Configure(EntityTypeBuilder<VwFaq> entity)
        {
            entity.HasNoKey();

            entity.ToView("VwFaq");


            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

        }
    }


}
