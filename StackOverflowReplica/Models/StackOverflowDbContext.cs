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
		}

		public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }

	}
}