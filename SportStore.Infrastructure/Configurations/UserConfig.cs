using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportStore.Domen.Models;

namespace SportStore.Infrastructure.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //builder.Property(x => x.Name).IsRequired();
        //builder.Property(x => x.Description).IsRequired();
        //builder.Property(x => x.Location).IsRequired();
        //builder.Property(x => x.TimeInMinutes).IsRequired();
        //builder.Property(x => x.Length).IsRequired();
    }
}
