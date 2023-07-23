using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.DataAccess.Repos
{
	public class InterviewRepository : BaseRepository<Interview>, IInterviewRepository
	{
		public InterviewRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
