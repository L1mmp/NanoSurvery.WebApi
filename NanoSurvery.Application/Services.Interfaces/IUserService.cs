using NanoSurvery.Domain.Dtos;
using NanoSurvery.Domain.Entities;

namespace NanoSurvery.Application.Services.Interfaces
{
	public interface IUserService
	{
		public Task<bool> AddAsync(UserDto dto);
		public Task<bool> AddAsync(User entity);
		public Task<User> GetUserById(Guid userId);
		public Task<User> GetUserByLogin(string login);
		public Task<bool> UnRegisterUser(UserDto dto);
		public Task UpdateRefreshTokenAsync(User user);
		public Task UpdateUserAsync(User user);
	}
}
