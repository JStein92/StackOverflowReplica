using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StackOverflowReplica.Models
{
    public class StackOverflowDbContext : IdentityDbContext<ApplicationUser>
	{
		public StackOverflowDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException(nameof(builder));
			}

			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>().Property(u => u.UserName).HasMaxLength(128);

			//Uncomment this to have Email length 128 too (not neccessary)
			//modelBuilder.Entity<ApplicationUser>().Property(u => u.Email).HasMaxLength(128);

			builder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(128);

			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail)
				.HasMaxLength(255));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName)
				.HasMaxLength(255));

			builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName)
				.HasMaxLength(255));

			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)
				.HasMaxLength(255));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)
				.HasMaxLength(255));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));

			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)
				.HasMaxLength(255));

			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)
				.HasMaxLength(255));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)
				.HasMaxLength(255));

			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)
				.HasMaxLength(255));
		}

		public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }

	}
}