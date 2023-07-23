using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.DataAccess.Repos.Interfaces;
using NanoSurvery.DataAccess.Repos;
using NanoSurvery.Infrastructure.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoSurvery.Infrastructure.Providers;
using NanoSurvery.Infrastructure.Factories.Interfaces;
using NanoSurvery.Infrastructure.Factories;

namespace NanoSurvery.WebApi.Extensions
{
	public static partial class ServiceCollectionExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddTransient<IAuthService, AuthService>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IQuestionService, QuestionService>();
			services.AddTransient<ISurveyService, SurveyService>();
			services.AddTransient<IInterviewService, InterviewService>();
			services.AddScoped<IAnswerInerviewService, AnswerInerviewService>();
			services.AddTransient<TokenProvider>();

			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IQuestionRepository, QuestionRepository>();
			services.AddTransient<IAnswerRepository, AnswerRepository>();
			services.AddTransient<ISurveyRepository, SurveyRepository>();
			services.AddTransient<IInterviewRepository, InterviewRepository>();
			services.AddTransient<IAnswerInerviewRepositroy, AnswerInerviewRepositroy>();

			return services;
		}

		public static IServiceCollection AddFactories(this IServiceCollection services)
		{
			services.AddTransient<IInterviewFactory, InterviewFactory>();

			return services;
		}
	}
}
