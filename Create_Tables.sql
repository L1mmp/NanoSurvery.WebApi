CREATE TABLE Surveys
(
    Id UUID PRIMARY KEY,
    Title TEXT NOT NULL,
    Description TEXT,
    CreatedOn TIMESTAMP
);

CREATE TABLE Questions
(
    Id UUID PRIMARY KEY,
    SurveyId UUID REFERENCES "Surveys" ("Id") ON DELETE CASCADE,
    Title TEXT NOT NULL,
    Number INTEGER
);

CREATE TABLE Answers
(
    Id UUID PRIMARY KEY,
    QuestionId UUID REFERENCES "Questions" ("Id") ON DELETE CASCADE,
    Text TEXT NOT NULL
);

CREATE TABLE Interviews
(
    Id UUID PRIMARY KEY,
    UserId UUID REFERENCES "Users" ("Id") ON DELETE CASCADE,
    SurveyId UUID REFERENCES "Surveys" ("Id") ON DELETE CASCADE,
    CurrentQuestionNumber INTEGER,
    IsFinished BOOLEAN
);

CREATE TABLE AnswerInterviews
(
    AnswerId UUID REFERENCES "Answers" ("Id") ON DELETE CASCADE,
    InterviewId UUID REFERENCES "Interviews" ("Id") ON DELETE CASCADE,
    PRIMARY KEY (AnswerId, InterviewId)
);

CREATE TABLE Users
(
    Id UUID PRIMARY KEY,
    Username TEXT NOT NULL,
    Password TEXT NOT NULL,
    RefreshToken TEXT,
    TokenCreated TIMESTAMP NOT NULL,
    TokenExpires TIMESTAMP NOT NULL
);


CREATE OR REPLACE VIEW AnswerInterviewResults AS
SELECT
	"q"."Id" AS "QuestionId",
	"q"."Title" AS "QuestionTitle",
	"a"."Id" AS "AnswerId",
	"a"."Text" AS "AnswerText",
	COUNT("ai"."AnswerId") AS "AnswerCount"
FROM
	"AnswerInterviews" "ai"
RIGHT JOIN "Answers" "a" 
	ON "a"."Id" = "ai"."AnswerId"
JOIN "Questions" "q" 
	ON "q"."Id" = "a"."QuestionId"
GROUP BY
	"q"."Id",
	"q"."Title",
	"a"."Id",
	"a"."Text"