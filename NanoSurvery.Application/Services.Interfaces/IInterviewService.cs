using NanoSurvery.Domain.Entities;

namespace NanoSurvery.Application.Services.Interfaces
{
	public interface IInterviewService
	{
		ValueTask<bool> CheckIsInterviewExists(Guid surveyId, Guid userId);
		ValueTask<Guid> CreateNewInterview(Guid surveyId, Guid userId);
		Task<Interview> FindByUserAndSurveyId(Guid userId, Guid surveyId);
		Task UpdateInterviewQuestionNumber(Interview interview);
	}
}