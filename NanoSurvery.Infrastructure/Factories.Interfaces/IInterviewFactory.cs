using NanoSurvery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Infrastructure.Factories.Interfaces
{
    public interface IInterviewFactory
    {
        public Interview CreateInterview();
        public Interview CreateInterview(Guid surveyId, Guid userId);

	}
}
