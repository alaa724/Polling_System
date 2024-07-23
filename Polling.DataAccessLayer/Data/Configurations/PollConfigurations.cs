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
    internal class PollConfigurations : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.Property(P => P.Title)
                .HasMaxLength(100)
                .IsRequired();


            builder.HasMany(P => P.Questions)
                .WithOne(Q => Q.Poll)
                .HasForeignKey(Q => Q.PollId);
        }
    }
}
