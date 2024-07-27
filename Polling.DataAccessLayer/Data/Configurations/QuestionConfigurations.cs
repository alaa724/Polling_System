using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.DataAccessLayer.Data.Configurations
{
    internal class QuestionConfigurations : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(Q => Q.Text)
                .IsRequired();

            builder.HasMany(Q => Q.Answers)
                .WithOne(A => A.Question)
                .HasForeignKey(A => A.QuestionId);
        }
    }
}
