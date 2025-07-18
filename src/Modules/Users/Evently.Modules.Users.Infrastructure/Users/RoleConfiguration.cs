using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Modules.Users.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evently.Modules.Users.Infrastructure.Users;
internal sealed class RoleConfiguration: IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");
        builder.HasKey(role => role.Name);
        builder.Property(role => role.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasMany<User>()
            .WithMany(user => user.Roles)
            .UsingEntity(joinbuilder =>
            {
                joinbuilder.ToTable("user_roles");
                joinbuilder.Property("RolesName").HasColumnName("role_name");
            });
        builder.HasData(
            Role.Administrator,
            Role.Member);
    }
}
