using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.Domain.Dtos;

namespace NanoSurvery.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionController : ControllerBase
	{
		private readonly IQuestionService _questionService;

		public QuestionController(IQuestionService questionService)
		{
			_questionService = questionService;
		}

		[HttpGet("getById")]
		[Authorize]
		public async Task<ActionResult<QuestionDto>> GetQuestion([FromQuery] Guid id)
		{
			try
			{
				var question = await _questionService.GetQuestionWithAnswers(id);

				return Ok(question);
			}
			catch (Exception ex)
			{

				return BadRequest(ex);
			}
		}

		[HttpGet("getFirstQuestion")]
		[Authorize]
		public async Task<ActionResult<QuestionDto>> GetFirstQuestionBySurveyId([FromQuery] Guid surveyId)
		{
			try
			{
				var question = await _questionService.GetFirstQuestionBySurveyId(surveyId);

				return Ok(question);
			}
			catch (Exception ex)
			{

				return BadRequest(ex);
			}
		}
	}
}
