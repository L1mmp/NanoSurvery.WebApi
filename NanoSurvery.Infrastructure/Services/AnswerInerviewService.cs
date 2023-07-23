using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.Domain.Entities;
using NanoSurvery.Domain.Exceptions;
using NanoSurvery.WebApi.Controllers;

namespace NanoSurvery.Infrastructure.Services
{
	public class AnswerInerviewService : IAnswerInerviewService
	{
		private readonly IAnswerInerviewRepositroy _answerInerviewRepositroy;
		private readonly ILogger<IAnswerInerviewService> _logger;
		private readonly IInterviewService _interviewService;
		private readonly IQuestionService _questionService;

		public AnswerInerviewService(
			IAnswerInerviewRepositroy answerInerviewRepositroy,
			ILogger<IAnswerInerviewService> logger,
			IQuestionService questionService,
			IInterviewService interviewService)
		{
			_answerInerviewRepositroy = answerInerviewRepositroy;
			_logger = logger;
			_questionService = questionService;
			_interviewService = interviewService;
		}


		public async Task AddAnswerInterview(Guid answerId, Guid InterviewId)
		{
			await _answerInerviewRepositroy.AddAsync(new AnswerInterviews { AnswerId = answerId, InterviewId = InterviewId });
		}

		public async Task AddAnswersInterview(List<Guid> answerIds, Guid InterviewId)
		{
			var answerInterviewList = new List<AnswerInterviews>();

			foreach (var answerId in answerIds)
			{
				answerInterviewList.Add(new AnswerInterviews
				{
					AnswerId = answerId,
					InterviewId = InterviewId
				});
			}

			try
			{
				await _answerInerviewRepositroy.AddRangeAsync(answerInterviewList);
			}
			catch (DbUpdateException e)
			{
				_logger.LogError(e.Message, e);
				throw;
			}

		}

		public async Task AddUserAnswerToInterview(AnswerQuestionDto answerDto, Guid userId)
		{
			try
			{
				var question = await _questionService.GetQuestionWithAnswers(answerDto.QuestionId);

				var interview = await _interviewService.FindByUserAndSurveyId(userId, question.SurveyId);

				await AddAnswersInterview(answerDto.Answers, interview.Id);

				await _interviewService.UpdateInterviewQuestionNumber(interview);
			}
			catch (DbUpdateException dbEx)
			{
				_logger.LogError(dbEx.Message, dbEx);
				throw new QuestionAlreadyAnsweredException($"User {userId} already answered to question {answerDto.QuestionId} with answers: {string.Join(',', answerDto.Answers)}");
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message, e);
				throw;
			}
		}
	}
}
