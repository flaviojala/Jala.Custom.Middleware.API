namespace Jala.Custom.Middleware.API.Middlewares;

public class QueryStringValueMiddleware
{
    private readonly RequestDelegate _next;

    public QueryStringValueMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        QueryHandler(context);
        await _next(context);
    }

    private void QueryHandler(HttpContext context)
    {
        var queryValue = context.Request.QueryString.Value;
        Console.WriteLine(string.IsNullOrEmpty(queryValue) ? "No value found" : queryValue);
    }
}

public static class UseQueryStringValueMiddlewareClass
{
    public static IApplicationBuilder UseQueryStringValueMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<QueryStringValueMiddleware>();
    }
}