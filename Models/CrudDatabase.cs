using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Models
{
	public class CrudDatabase : DbContext
	{
		public DbSet<CrudApplications> CrudApplication { get; set; }
		public CrudDatabase(DbContextOptions<CrudDatabase> options) : base(options) { }
	}
}
