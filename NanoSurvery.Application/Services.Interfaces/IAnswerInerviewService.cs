using NanoSurvery.Domain.Entities;
using NanoSurvery.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Application.Services.Interfaces
{
	public interface IAnswerInerviewService
	{
		public Task AddAnswerInterview(Guid answerId, Guid InterviewId);
		public Task AddAnswersInterview(List<Guid> answerIds, Guid InterviewId);
		Task AddUserAnswerToInterview(AnswerQuestionDto answerDto, Guid userId);
	}
}
