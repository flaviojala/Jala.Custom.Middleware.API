using Jala.Custom.Middleware.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseParamsMiddleware();

app.UseQueryStringValueMiddleware();

// app.Use(async (context, next) =>
// {
//     Console.WriteLine("Log Middleware");
//     
//     //Every time we write something in our response we are returning something to the client, if we try to invoke our middleware it will bring an exception
//     //If you to write something in your response you can't call the next middleware unless it's in the final middleware
//     await context.Response.WriteAsync("the End");
//     return;
//     //this code will not be executed.
//     await next.Invoke(context);
// });

app.MapControllers();

app.Run(async context =>
{
    await context.Response.WriteAsync("The End");
});

app.Run();