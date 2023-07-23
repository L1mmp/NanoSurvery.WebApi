using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Domain.Dtos
{
	public class AnswerDto
	{
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
    }
}
