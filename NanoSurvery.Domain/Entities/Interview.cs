using System.ComponentModel.DataAnnotations;

namespace NanoSurvery.Domain.Entities
{
	public class Interview
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; } = null!;
        public int CurrentQuestionNumber { get; set; }
        public bool IsFinished { get; set; }
		public ICollection<AnswerInterviews> Answers { get; set; }
	}
}
