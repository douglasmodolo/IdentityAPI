using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Data
{
	public class UserDbContext : IdentityDbContext<User>
	{
        public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
