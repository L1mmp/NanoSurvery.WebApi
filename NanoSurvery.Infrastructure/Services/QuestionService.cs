using AutoMapper;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Infrastructure.Services
{
	public class QuestionService : IQuestionService
	{
		private readonly IQuestionRepository _questionRepository;
		private readonly IMapper _mapper;

		public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
		{
			_questionRepository = questionRepository;
			_mapper = mapper;
		}

		public async Task<QuestionDto> GetQuestionWithAnswers(Guid id)
		{
			var question = await _questionRepository.GetQuestionWithAnswers(id);

			var nextQuestionId = (await _questionRepository
				.GetByConditionAsync(x => x.Number == (question.Number + 1) && x.SurveyId == question.SurveyId))
				.FirstOrDefault()?.Id;

			var dto = _mapper.Map<QuestionDto>(question);

			dto.NextQuestionId = nextQuestionId ?? Guid.Empty;

			return dto;
		}

		public async Task<QuestionDto> GetFirstQuestionBySurveyId(Guid surveyId)
		{
			var question = (await _questionRepository.GetByConditionAsync(x => x.SurveyId == surveyId && x.Number == 0))
				.FirstOrDefault();

			return question is null
				? throw new NullReferenceException($"Questions with Survey Id: {surveyId} not found.")
				: await this.GetQuestionWithAnswers(question!.Id);
		}
	}
}
