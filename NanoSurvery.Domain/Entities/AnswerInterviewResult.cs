using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Domain.Entities
{
	public class AnswerInterviewResult
	{
		public Guid QuestionId { get; set; }
		public Guid AnswerId { get; set; }
		public string QuestionTitle { get; set; } = null!;
        public string AnswerText { get; set; } = null!;
		public long AnswerCount { get; set; }

	}
}
