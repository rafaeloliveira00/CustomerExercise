using System.Reflection;
using Connectlime.Application.Common.Interfaces;
using Connectlime.Application.Common.Security;

namespace Connectlime.Application.Common.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUser _user;

    public AuthorizationBehaviour(IUser user)
    {
        _user = user;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // check if the request has the Authorize attribute
        // right now we do not have any protected request nor login (out of the scope of this exercise)
        IEnumerable<AuthorizeAttribute> authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        // here it checks if the current request has the Authorize attribute and if we have a valid user login
        if (authorizeAttributes.Any() && _user.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        return await next();
    }
}
