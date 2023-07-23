using System.ComponentModel.DataAnnotations;

namespace NanoSurvery.Domain.Entities
{
	public class Survey
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
