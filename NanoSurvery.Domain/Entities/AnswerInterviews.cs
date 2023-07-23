using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Domain.Entities
{
	public class AnswerInterviews
	{
        public Guid AnswerId { get; set; }
        public Answer Answer { get; set; } = null!;
        public Guid InterviewId { get; set; }
		public Interview Interview { get; set; } = null!;
	}
}
