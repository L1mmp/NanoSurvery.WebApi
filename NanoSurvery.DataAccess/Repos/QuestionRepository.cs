using Microsoft.EntityFrameworkCore;
using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.DataAccess.Repos
{
	public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
	{
		public QuestionRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<Question> GetQuestionWithAnswers(Guid id)
		{
			return (await _dbContext
						.Questions
						.Include(x => x.Answers)
						.FirstOrDefaultAsync(x => x.Id == id))!;
		}
	}
}
