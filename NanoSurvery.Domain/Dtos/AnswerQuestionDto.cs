namespace NanoSurvery.WebApi.Controllers
{
	public class AnswerQuestionDto
	{
		public Guid QuestionId { get; set; }
		public List<Guid> Answers { get; set; } = null!;
    }
}