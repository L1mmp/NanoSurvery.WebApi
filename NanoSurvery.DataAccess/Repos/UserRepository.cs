using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.Domain.Entities;

namespace NanoSurvery.DataAccess.Repos
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
