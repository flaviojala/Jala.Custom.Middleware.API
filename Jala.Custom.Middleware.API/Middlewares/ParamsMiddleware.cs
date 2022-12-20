namespace Jala.Custom.Middleware.API.Middlewares;

//middleware connot be a static class
public class ParamsMiddleware
{
    private readonly RequestDelegate _next;

    public ParamsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ParamHandler(context);
        await _next(context);
    }

    private void ParamHandler(HttpContext context)
    {
        context.Items["AppName"] = "Weather";
        if (context.Request.Path.HasValue == true && context.Request.Path.Value.Contains("GetWeatherForecast"))
            Console.WriteLine("Yes");
    }
    
}
//extension method can only be created in static classes
public static class UseParamsMiddlewareClass
{
    public static IApplicationBuilder UseParamsMiddleware(this IApplicationBuilder builder)
    {
       return builder.UseMiddleware<ParamsMiddleware>();
    }
}