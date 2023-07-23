using Microsoft.EntityFrameworkCore;
using NanoSurvery.Domain.Entities;
using System.Reflection.Metadata;

namespace NanoSurvery.DataAccess;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{ }
	public DbSet<Answer> Answers { get; set; } = null!;
	public DbSet<Question> Questions { get; set; } = null!;
	public DbSet<Survey> Surveys { get; set; } = null!;
	public DbSet<Interview> Interviews { get; set; } = null!;
	public DbSet<User> Users { get; set; } = null!;
	public DbSet<AnswerInterviews> AnswerInterviews { get; set; } = null!;
	public DbSet<AnswerInterviewResult> AnswerInterviewResults { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AnswerInterviews>()
			.HasKey(c => new { c.AnswerId, c.InterviewId });

		modelBuilder.Entity<AnswerInterviews>()
			.HasOne(ai => ai.Answer)
			.WithMany(ai => ai.Interviews)
			.HasForeignKey(ai => ai.AnswerId);

		modelBuilder.Entity<AnswerInterviews>()
			.HasOne(ai => ai.Interview)
			.WithMany(ai => ai.Answers)
			.HasForeignKey(ai => ai.InterviewId);


		modelBuilder.Entity<AnswerInterviewResult>()
			.ToView("AnswerInterviewResults")
			.HasKey(x => new { x.QuestionId , x.AnswerId});

		var survey1 = new Survey { Id = Guid.NewGuid(), Title = "Survey 1", Description = "Description for Survey 1", CreatedOn = DateTime.UtcNow };
		var survey2 = new Survey { Id = Guid.NewGuid(), Title = "Survey 2", Description = "Description for Survey 2", CreatedOn = DateTime.UtcNow };

		modelBuilder.Entity<Survey>().HasData(survey1, survey2);

		// Seed data for Questions with their relationship to Surveys
		var question1 = new Question { Id = Guid.NewGuid(), SurveyId = survey1.Id, Title = "Question 1", Number = 0 };
		var question2 = new Question { Id = Guid.NewGuid(), SurveyId = survey1.Id, Title = "Question 2", Number = 1 };
		var question3 = new Question { Id = Guid.NewGuid(), SurveyId = survey2.Id, Title = "Question 1", Number = 0 };
		var question4 = new Question { Id = Guid.NewGuid(), SurveyId = survey2.Id, Title = "Question 2", Number = 1 };

		modelBuilder.Entity<Question>().HasData(question1, question2, question3, question4);

		// Seed data for Answers with their relationship to Questions

		var answer1 = new Answer { Id = Guid.NewGuid(), QuestionId = question1.Id, Text = "Answer 1" };
		var answer2 = new Answer { Id = Guid.NewGuid(), QuestionId = question1.Id, Text = "Answer 2" };
		var answer3 = new Answer { Id = Guid.NewGuid(), QuestionId = question1.Id, Text = "Answer 3" };
		var answer4 = new Answer { Id = Guid.NewGuid(), QuestionId = question2.Id, Text = "Answer 1" };
		var answer5 = new Answer { Id = Guid.NewGuid(), QuestionId = question2.Id, Text = "Answer 2" };
		var answer6 = new Answer { Id = Guid.NewGuid(), QuestionId = question3.Id, Text = "Answer 1" };
		var answer7 = new Answer { Id = Guid.NewGuid(), QuestionId = question3.Id, Text = "Answer 2" };
		var answer8 = new Answer { Id = Guid.NewGuid(), QuestionId = question4.Id, Text = "Answer 1" };
		var answer9 = new Answer { Id = Guid.NewGuid(), QuestionId = question4.Id, Text = "Answer 2" };

		modelBuilder.Entity<Answer>().HasData(answer1, answer2, answer3, answer4, answer5, answer6, answer7);

		// Seed data for Users
		var user1 = new User { Id = Guid.NewGuid(), Username = "user1", Password = "password1", RefreshToken = null, TokenCreated = DateTime.UtcNow, TokenExpires = DateTime.UtcNow.AddDays(7) };
		var user2 = new User { Id = Guid.NewGuid(), Username = "user2", Password = "password2", RefreshToken = null, TokenCreated = DateTime.UtcNow, TokenExpires = DateTime.UtcNow.AddDays(7) };

		modelBuilder.Entity<User>().HasData(user1, user2);

		// Seed data for Interviews with their relationship to Users and Surveys
		var interview1 = new Interview { Id = Guid.NewGuid(), UserId = user1.Id, SurveyId = survey1.Id };
		var interview2 = new Interview { Id = Guid.NewGuid(), UserId = user2.Id, SurveyId = survey1.Id };
		var interview3 = new Interview { Id = Guid.NewGuid(), UserId = user1.Id, SurveyId = survey2.Id };
		var interview4 = new Interview { Id = Guid.NewGuid(), UserId = user2.Id, SurveyId = survey2.Id };

		modelBuilder.Entity<Interview>().HasData(interview1, interview2, interview3, interview4);

		var answerInterview1 = new AnswerInterviews { AnswerId = answer1.Id, InterviewId = interview1.Id };
		var answerInterview2 = new AnswerInterviews { AnswerId = answer4.Id, InterviewId = interview1.Id };
		var answerInterview3 = new AnswerInterviews { AnswerId = answer6.Id, InterviewId = interview3.Id };
		var answerInterview4 = new AnswerInterviews { AnswerId = answer3.Id, InterviewId = interview2.Id };
		var answerInterview5 = new AnswerInterviews { AnswerId = answer5.Id, InterviewId = interview2.Id };
		var answerInterview6 = new AnswerInterviews { AnswerId = answer7.Id, InterviewId = interview4.Id };

		modelBuilder.Entity<AnswerInterviews>().HasData(answerInterview1, answerInterview2, answerInterview3, answerInterview4, answerInterview5, answerInterview6);
	}
}