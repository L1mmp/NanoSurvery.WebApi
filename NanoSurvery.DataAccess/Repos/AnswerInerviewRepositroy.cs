using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.Domain.Entities;

namespace NanoSurvery.DataAccess.Repos
{
	public class AnswerInerviewRepositroy : BaseRepository<AnswerInterviews>, IAnswerInerviewRepositroy
	{
		public AnswerInerviewRepositroy(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public async Task AddRangeAsync(IEnumerable<AnswerInterviews> answerInerviews)
		{
			await _dbContext.AnswerInterviews.AddRangeAsync(answerInerviews);


			await _dbContext.SaveChangesAsync();
		}
	}
}
