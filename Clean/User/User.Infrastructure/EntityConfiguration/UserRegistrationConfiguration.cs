using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.UserRegistration;

namespace User.Infrastructure.EntityTypeConfiguration
{
    internal class UserRegistrationConfiguration : IEntityTypeConfiguration<UserRegistration>
    {
        public void Configure(EntityTypeBuilder<UserRegistration> builder)
        {
            builder.ToTable("clean.user.user_registrations");

            builder.HasKey("id");

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(
                    c => c.Value,
                    c => UserRegistrationId.From(c)
                );

            //builder.Property(x => x.UserRegistrationStatus)
            //    .IsRequired()
            //    .HasMaxLength(100)
            //    .HasConversion(
            //        c => c.AsString(),
            //        c => UserRegistrationStatus.From(c)
            //    );

            //builder.Property(x => x.EmailAddress)
            //    .IsRequired()
            //    .HasMaxLength(100)
            //    .HasConversion(
            //        c => c.Value,
            //        c => EmailAddress.From(c)
            //    );

            //// TODO: handle multiple value valueobject
            //builder.Property(x => x.FullName)
            //    .IsRequired()
            //    .HasMaxLength(100)
            //    .HasConversion(
            //        c => c.FirstName,
            //        c => FullName.From(c)
            //    );

            //builder.Property(x => x.Password)
            //    .IsRequired()
            //    .HasMaxLength(100)
            //    .HasConversion(
            //        c => c.Value,
            //        c => Password.From(c)
            //    );

            //builder.Property(x => x.Gender)
            //    .IsRequired()
            //    .HasConversion(
            //        c => (int)c,
            //        c => (Gender)c
            //    );
        }
    }
}
