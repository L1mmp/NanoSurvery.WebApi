using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Domain.Exceptions
{
	[Serializable]
	public class InterviewNotFoundException : Exception
	{
		public InterviewNotFoundException() { }

		public InterviewNotFoundException(string message) : base(message) { }

		public InterviewNotFoundException(string message, Exception inner)
		: base(message, inner)
		{
		}
	}
}
