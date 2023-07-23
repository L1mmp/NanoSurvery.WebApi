using NanoSurvery.Domain.Dtos;
using NanoSurvery.Domain.Entities;

namespace NanoSurvery.DataAccess.Repos.Interfaces
{
	public interface IQuestionRepository : IBaseRepository<Question>
	{
		public Task<Question> GetQuestionWithAnswers(Guid id);
	}
}