using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowReplica.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentBody { get; set; }
        public int VoteCount { get; set; }
        public int BestResponseId { get; set; }
        //public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Response> Responses { get; set; }

        public Question()
        {
            this.VoteCount = 1;
        }
	}


}