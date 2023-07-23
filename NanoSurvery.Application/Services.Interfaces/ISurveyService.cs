using NanoSurvery.Domain.Dtos;
using NanoSurvery.Domain.Entities;

namespace NanoSurvery.Application.Services.Interfaces
{
	public interface ISurveyService
	{
		public Task<IEnumerable<SurveyDto>> GetAll();
		public Task<QuestionDto> StartSurvey(Guid surveyId, Guid userId);
	}
}