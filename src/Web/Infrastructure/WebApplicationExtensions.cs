using System.Reflection;

namespace Connectlime.Web.Infrastructure;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group, string name = "")
    {
        string groupName;

        if (string.IsNullOrEmpty(name))
        {
            groupName = group.GetType().Name;
        }
        else
        {
            groupName = name;
        }

        return app
            .MapGroup($"/api/{groupName}")
            .WithGroupName(groupName)
            .WithTags(groupName)
            .WithOpenApi();
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        Type endpointGroupType = typeof(EndpointGroupBase);

        Assembly assembly = Assembly.GetExecutingAssembly();

        IEnumerable<Type> endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (Type type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}
