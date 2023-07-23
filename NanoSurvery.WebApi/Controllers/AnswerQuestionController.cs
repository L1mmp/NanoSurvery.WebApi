using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.Domain.Dtos;
using NanoSurvery.Domain.Exceptions;

namespace NanoSurvery.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnswerQuestionController : ControllerBase
	{
		private readonly IAnswerInerviewService _answerInerviewService;
		private readonly IHttpContextAccessor _httpContext;

		public AnswerQuestionController(
			IHttpContextAccessor httpContext,
			IAnswerInerviewService answerInerviewService)
		{
			_httpContext = httpContext;
			_answerInerviewService = answerInerviewService;
		}


		[HttpPost("answer")]
		[Authorize]
		public async Task<ActionResult<QuestionDto>> AnswerToQuestion(AnswerQuestionDto answerDto)
		{
			var userIdClaim = _httpContext.HttpContext?.User.FindFirst(x => x.Type == "Id")?.Value;

			try
			{
				if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
				{
					return BadRequest("User claims not found");
				}


				await _answerInerviewService.AddUserAnswerToInterview(answerDto, userId);
			}
			catch (InterviewNotFoundException ie)
			{
				return BadRequest(ie.Message);
			}
			catch (QuestionAlreadyAnsweredException qe)
			{
				return BadRequest(qe.Message);
			}
			

			return Ok($"Question {answerDto.QuestionId} successfully answered {string.Join(',', answerDto.Answers)}");
		}
	}
}
