using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models
{
	public class CrudApplications
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }	
		public string Designation { get; set; }

		public DateTime CreatedDateTime { get; set; } = DateTime.Now;
	}
}
