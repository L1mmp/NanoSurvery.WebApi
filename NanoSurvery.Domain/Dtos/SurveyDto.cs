using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Domain.Dtos
{
	public class SurveyDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = null!;
		public string? Description { get; set; }
		public DateTime CreatedOn { get; set; }
        public Guid FirstQuestionId { get; set; }
    }
}
