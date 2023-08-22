using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SampleProject.Business.Utilities.AuthorizeHelpers;
using SampleProject.Business.Utilities.Session;
using SampleProject.Core.Constant;
using SampleProject.Core.Exceptions;
using SampleProject.Core.Utilities.AppSettings;
using SampleProject.Core.Utilities.Attributes;
using SampleProject.Model.Authorize;
using System.Net;

namespace SampleProject.Api.Middlewares
{
    public class CustomAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<SampleSettings> _sampleSettings;

        public CustomAuthMiddleware(RequestDelegate next, IOptions<SampleSettings> portalSettings)
        {
            _next = next;
            _sampleSettings = portalSettings;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var endpoint = httpContext.GetEndpoint();

            if (endpoint is not null)
            {
                var hasPerm = endpoint.Metadata.OfType<HasPermissionAttribute>().ToList();

                if (hasPerm is not null && hasPerm.Count != 0)
                {
                    var token = httpContext.Request.Headers["Authorization"].ToString();

                    if (token.IsNullOrEmpty())
                        throw new CustomException(TokenConstant.NOT_FOUND_TOKEN, HttpStatusCode.Unauthorized);

                    try
                    {
                        var tokenHelper = new TokenHelper(_sampleSettings);
                        var loginUser = tokenHelper.ValidateToken(token);

                        if (loginUser is null)
                            throw new CustomException(TokenConstant.INVALID_TOKEN, HttpStatusCode.Unauthorized);

                        new SessionManager(httpContext)
                        {
                            User = new UserSessionModel
                            {
                                Username = loginUser.Username,
                                PersonnelId = loginUser.PersonnelId,
                                Roles = loginUser.Roles
                            }
                        };

                    }
                    catch (CustomException customException)
                    {
                        throw customException;
                    }
                    catch (Exception)
                    {
                        throw new CustomException(TokenConstant.NOT_FOUND_TOKEN, HttpStatusCode.Unauthorized);
                    }
                }

            }

            await _next(httpContext);
        }
    }
    public static class CustomAuthMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthMiddleware>();
        }
    }
}
