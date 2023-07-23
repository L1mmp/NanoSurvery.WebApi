using System.ComponentModel.DataAnnotations;

namespace NanoSurvery.Domain.Entities
{
	public class Answer
    {
        [Key]
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public string Text { get; set; } = null!;
        public ICollection<AnswerInterviews> Interviews { get; set; }
	}
}
