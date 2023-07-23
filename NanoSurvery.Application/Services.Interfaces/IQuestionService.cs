using NanoSurvery.Domain.Dtos;

namespace NanoSurvery.Application.Services.Interfaces
{
	public interface IQuestionService
	{
		Task<QuestionDto> GetQuestionWithAnswers(Guid id);
		Task<QuestionDto> GetFirstQuestionBySurveyId(Guid surveyId);
	}
}