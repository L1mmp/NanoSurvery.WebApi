using AutoMapper;
using Microsoft.Extensions.Logging;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.Domain.Dtos;
using NanoSurvery.Domain.Entities;

namespace NanoSurvery.Infrastructure.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepo;
		private readonly IMapper _mapper;
		private readonly ILogger<IUserService> _logger;

		public UserService(IUserRepository userRepo, IMapper mapper, ILogger<IUserService> logger)
		{
			_userRepo = userRepo;
			_mapper = mapper;
			_logger = logger;
		}
		public async Task<bool> UnRegisterUser(UserDto dto)
		{
			var entity = (await _userRepo.GetByConditionAsync(x => x.Username == dto.Username)).FirstOrDefault();

			if (entity == null)
			{
				return false;
			}

			try
			{
				await _userRepo.DeleteByIdAsync(entity!.Id);
			}
			catch (Exception ex)
			{
				_logger.LogError("Error while deleting user: ", ex.Message);
				throw;
			}

			return true;
		}

		private async Task<bool> IsUserExists(UserDto dto)
		{
			return (await _userRepo.GetByConditionAsync(x => x.Username == dto.Username)).Any();
		}

		public async Task<bool> AddAsync(UserDto dto)
		{
			var isExists = await IsUserExists(dto);

			if (!isExists)
			{
				return false;
			}

			var entity = _mapper.Map<User>(dto);

			return (await _userRepo.AddAsync(entity)).State == Microsoft.EntityFrameworkCore.EntityState.Added;
		}

		public async Task<bool> AddAsync(User entity)
		{
			var user = await _userRepo.GetByIdAsync(entity.Id);

			if (user != null)
			{
				return false;
			}

			return (await _userRepo.AddAsync(entity)).State == Microsoft.EntityFrameworkCore.EntityState.Added;
		}

		public async Task<User> GetUserByLogin(string login)
		{
			try
			{
				var user = (await _userRepo.GetByConditionAsync(x => x.Username == login)).FirstOrDefault() ?? default;
				return user;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task UpdateRefreshTokenAsync(User user)
		{
			await _userRepo.UpdateAsync(user);
		}

		public async Task<User> GetUserById(Guid userId)
		{
			return await _userRepo.GetByIdAsync(userId);
		}

		public async Task UpdateUserAsync(User user)
		{
			await _userRepo.UpdateAsync(user);
		}
	}
}
