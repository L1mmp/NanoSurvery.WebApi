using NanoSurvery.Domain.Entities;
using NanoSurvery.Infrastructure.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Infrastructure.Factories
{
	public class InterviewFactory : IInterviewFactory
	{
		public Interview CreateInterview()
		{
			return new Interview();
		}

		public Interview CreateInterview(Guid surveyId, Guid userId)
		{
			return new Interview
			{
				UserId = userId,
				SurveyId = surveyId,
				CurrentQuestionNumber = 0,
				IsFinished = false
			};
		}
	}
}
