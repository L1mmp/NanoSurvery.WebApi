using System.ComponentModel.DataAnnotations;

namespace NanoSurvery.Domain.Entities
{
	public class Question
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; } = null!;
        public string? Title { get; set; }
        public int Number { get; set; }
		public List<Answer> Answers { get; set; } = null!;
	}
}
