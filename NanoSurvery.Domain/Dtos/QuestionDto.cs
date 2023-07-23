using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Domain.Dtos
{
	public class QuestionDto
	{
		public Guid Id { get; set; }
        public string Title { get; set; } = null!;
		public List<AnswerDto> Answers { get; set; } = null!;
		public Guid NextQuestionId { get; set; }
		public Guid InterviewId { get; set; }
		public Guid SurveyId { get; set; }
	}
}
