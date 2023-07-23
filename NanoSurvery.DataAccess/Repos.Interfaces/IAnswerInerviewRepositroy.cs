using NanoSurvery.Domain.Entities;

namespace NanoSurvery.DataAccess.Repos.Interfaces
{
	public interface IAnswerInerviewRepositroy : IBaseRepository<AnswerInterviews>
	{
		public Task AddRangeAsync(IEnumerable<AnswerInterviews> answerInerviews);
	}
}