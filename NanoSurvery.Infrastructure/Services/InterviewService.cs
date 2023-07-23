using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.Domain.Entities;
using NanoSurvery.Domain.Exceptions;
using NanoSurvery.Infrastructure.Factories.Interfaces;

namespace NanoSurvery.Infrastructure.Services
{
	public class InterviewService : IInterviewService
	{
		private readonly IInterviewFactory _interviewFactory;
		private readonly IInterviewRepository _interviewRepository;
		private readonly ILogger<IInterviewService> _logger;

		public InterviewService(
			IInterviewFactory interviewFactory, 
			IInterviewRepository interviewRepository, 
			ILogger<IInterviewService> logger)
		{
			_interviewFactory = interviewFactory;
			_interviewRepository = interviewRepository;
			_logger = logger;
		}

		public async ValueTask<Guid> CreateNewInterview(Guid surveyId, Guid userId)
		{
			var interview = _interviewFactory.CreateInterview(surveyId, userId);

			try
			{
				var entry = await _interviewRepository.AddAsync(interview);

				return entry.Entity.Id;
			}
			catch (DbUpdateException e)
			{
				_logger.LogError(e.Message, e);

				throw;
			}
		}

		public async ValueTask<bool> CheckIsInterviewExists(Guid surveyId, Guid userId)
		{
			var interview = (await _interviewRepository
				.GetByConditionAsync(x => x.SurveyId == surveyId && x.UserId == userId))
				.FirstOrDefault();

			return interview is not null;
		}

		public async Task<Interview> FindByUserAndSurveyId(Guid userId, Guid surveyId)
		{
			var interview = (await _interviewRepository
				.GetByConditionAsync(x => x.SurveyId == surveyId && x.UserId == userId))
				.FirstOrDefault();

			return interview ?? throw new InterviewNotFoundException($"Interview not found for user: {userId}. Survey: {surveyId}");
		}

		public async Task UpdateInterviewQuestionNumber(Interview interview)
		{
			interview.CurrentQuestionNumber++;

			await _interviewRepository.UpdateAsync(interview);
		}
	}
}
