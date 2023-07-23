using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.Domain.Dtos;
using NanoSurvery.Domain.Exceptions;
using System.Security.Claims;

namespace NanoSurvery.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SurveyController : ControllerBase
	{
		private readonly ISurveyService _surveyService;
		private readonly IHttpContextAccessor _httpContext;

		public SurveyController(ISurveyService surveyService, IHttpContextAccessor httpContext)
		{
			_surveyService = surveyService;
			_httpContext = httpContext;
		}

		[HttpGet("getAll")]
		[Authorize]
		public async Task<ActionResult<IEnumerable<SurveyDto>>> GetAllSurveys()
		{
			try
			{
				var surveys = await _surveyService.GetAll();

				if (surveys.Any())
				{
					return Ok(surveys);
				}

				return NotFound(surveys);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}

		}

		[Authorize]
		[HttpGet("start")]
		public async Task<ActionResult<QuestionDto>> StartSurvey(Guid surveyId)
		{
			var userIdClaim = _httpContext.HttpContext?.User.FindFirst(x => x.Type == "Id")?.Value ?? "";

			if (!Guid.TryParse(userIdClaim, out var userId))
			{
				return BadRequest("User claims not found");
			}

			try
			{
				var question = await _surveyService.StartSurvey(surveyId, userId);
				//TODO: Need to handle exception survey alreay started.


				return Ok(question);

			}
			catch (SurveyAlreadyStartedException e)
			{

				return BadRequest(e.Message);
			}

		}
	}
}
