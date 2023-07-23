using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NanoSurvery.Application.Services.Interfaces;
using NanoSurvery.DataAccess;
using NanoSurvery.Domain.Mappings;
using NanoSurvery.Infrastructure.Providers;
using NanoSurvery.Infrastructure.Services;
using NanoSurvery.WebApi.Extensions;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfigured();

builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddFactories();

builder.Services.AddControllers();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
	opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
	{
		Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
		In = ParameterLocation.Header,
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey
	});
});
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
	opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

builder.Services.AddAuthentication(
	JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(opt =>
	{
		opt.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
				.GetBytes(builder.Configuration.GetSection("TokenSource:Token").Value!)),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});


builder.Services.AddAutoMapper(typeof(DtoToEntitesProfile));


var app = builder
	.Build()
	.MigrateDatabase<ApplicationDbContext>();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseSerilogRequestLogging();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

