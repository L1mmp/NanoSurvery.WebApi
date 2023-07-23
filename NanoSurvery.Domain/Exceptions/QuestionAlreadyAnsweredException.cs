using System.Runtime.Serialization;

namespace NanoSurvery.Domain.Exceptions
{
	[Serializable]
	public class QuestionAlreadyAnsweredException : Exception
	{
		public QuestionAlreadyAnsweredException()
		{
		}

		public QuestionAlreadyAnsweredException(string? message) : base(message)
		{
		}

		public QuestionAlreadyAnsweredException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected QuestionAlreadyAnsweredException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}