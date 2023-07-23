# NanoSurvery.WebApi

# Using SQL Server database
You can create migration to postgers or e.t.c for example:
 1) Change Program.cs configuration to use Npgsql or e.t.c.
 2) You need to Remove-Migration, then Add-Migration
 3) Migration will automatically applied to database at the start of application.
# Authorization with jwt tokens.
1) You need to register user .../api/Auth/register
2) You need to login .../api/Auth/login. After successful login it will responce with JWT-token. To use this u need to add header "Authorization" with values "Bearer {token}" (In token u paste ur token, without {} brackets).
# Api Usage:

P.S Use swagger doc to get request and responce info.
