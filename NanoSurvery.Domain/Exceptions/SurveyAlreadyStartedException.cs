using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoSurvery.Domain.Exceptions
{
	[Serializable]
	public class SurveyAlreadyStartedException : Exception
	{
		public SurveyAlreadyStartedException() { }

		public SurveyAlreadyStartedException(string message) : base(message) { }

		public SurveyAlreadyStartedException(string message, Exception inner)
		: base(message, inner)
		{
		}
	}
}
