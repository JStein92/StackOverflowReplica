using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowReplica.Models
{
	[Table("Responses")]
	public class Response
	{
		[Key]
		public int Id { get; set; }
		public string ContentBody { get; set; }
		public int VoteCount { get; set; }
        public int QuestionId { get; set; }

		public virtual ApplicationUser User { get; set; }
        public virtual Question Question { get; set; }
	}
}