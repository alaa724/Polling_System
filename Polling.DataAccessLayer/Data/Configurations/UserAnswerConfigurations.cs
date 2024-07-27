//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Polling.DataAccessLayer.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Polling.DataAccessLayer.Data.Configurations
//{
//    internal class UserAnswerConfigurations : IEntityTypeConfiguration<UserAnswer>
//    {
//        public void Configure(EntityTypeBuilder<UserAnswer> builder)
//        {
//            builder.HasKey(UA => UA.Id);

//            builder.HasOne(UA => UA.User)
//                .WithMany()
//                .HasForeignKey(UA => UA.UserId)
//                .OnDelete(DeleteBehavior.NoAction);

//            builder.HasOne(UA => UA.Question)
//                .WithMany()
//                .HasForeignKey(UA => UA.QuestionId)
//                .OnDelete(DeleteBehavior.NoAction);

//            builder.HasOne(UA => UA.Answer)
//                .WithMany()
//                .HasForeignKey(UA => UA.AnswerId)
//                .OnDelete(DeleteBehavior.NoAction);
//        }
//    }
//}
