using AutoMapper;
using Microsoft.Extensions.Logging;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.Domain.Dtos;
using NanoSurvery.Domain.Exceptions;

namespace NanoSurvery.Infrastructure.Services
{
	public class SurveyService : ISurveyService
	{
		private readonly ISurveyRepository _surveyRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<ISurveyService> _logger;
		private readonly IQuestionService _questionService;
		private readonly IInterviewService _interviewService;

		public SurveyService(
			ISurveyRepository surveyRepository,
			IMapper mapper,
			ILogger<ISurveyService> logger,
			IQuestionService questionService,
			IInterviewService interviewService)
		{
			_surveyRepository = surveyRepository;
			_mapper = mapper;
			_logger = logger;
			_questionService = questionService;
			_interviewService = interviewService;
		}

		public async Task<IEnumerable<SurveyDto>> GetAll()
		{
			var entities = await _surveyRepository.GetAllAsync();

			return _mapper.Map<IEnumerable<SurveyDto>>(entities);
		}
		public async Task<QuestionDto> StartSurvey(Guid surveyId, Guid userId)
		{
			var isSurveyStarted = await _interviewService.CheckIsInterviewExists(surveyId, userId);

			if(isSurveyStarted)
			{
				throw new SurveyAlreadyStartedException($"Survey {surveyId} for user {userId} already started.");
			}

			try
			{
				var interviewId = await _interviewService.CreateNewInterview(surveyId, userId);

				var question = await _questionService.GetFirstQuestionBySurveyId(surveyId);

				question.InterviewId = interviewId;

				return question;
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message, e);
				throw;
			}
		}



	}
}
