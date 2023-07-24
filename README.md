# NanoSurvery.WebApi

# Using different database
You can create migration to postgers or e.t.c for example:
 1) Change Program.cs configuration to use Npgsql or e.t.c.
 2) You need to Remove-Migration, then Add-Migration
 3) Migration will automatically applied to database at the start of application.
# Authorization with jwt tokens.
1) You need to register user .../api/Auth/register
2) You need to login .../api/Auth/login. After successful login it will responce with JWT-token. To use this u need to add header "Authorization" with values "Bearer {token}" (In token u paste ur token, without {} brackets).
# Api Usage(Only authorized users):
1) You can get all Surveys [GET] ...api/Survey/getAll
2) You can start survey [GET] ...api/Survey/start?surveyId
3) You can answer for current question [POST] ...api/AnswerQuestion/answer
 {
  questionId: "247f9d62-a814-417f-a56f-c96939a5f4ee",
  answers:
   ["247f9d62-a814-417f-a56f-c96939a5f4ee","247f9d62-a814-417f-a56f-c96939a5f4ee","247f9d62-a814-417f-a56f-c96939a5f4ee"]
 }
4) You can get next question [GET] ...api/Question/getById?id
5) You can get first question of survey [GET] ...api/Question/getFirstQuestion?surveyId
P.S Use swagger doc to get request and responce info.
