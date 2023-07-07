using ClubSwimmers.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.Use(async (context, next) =>
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"A before");
    await next.Invoke();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"A After");
    Console.ResetColor();
});


app.Map("/usingmapbranch", builder =>
{
    builder.Use(async (context, next) =>
    {
        Console.WriteLine("Map branch logic in the Use method before the next delegate");
        await next.Invoke();
        Console.WriteLine("Map branch logic in the Use method after the next delegate");
    });

    builder.Run(async context =>
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"map branch response to the client in the Run method");
        await context.Response.WriteAsync("Hello from the map branch.");
        Console.ResetColor();
    });

});

app.MapWhen(context =>
    context.Request.Query.ContainsKey("testquerystring"),
    builder
    =>
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        builder.Run(async context =>
        {
            await context.Response.WriteAsync("Hello from the MapWhen branch.");
        });
        Console.ResetColor();
    });

app.Run(async context =>
{
    Console.WriteLine($"C");
    await context.Response.WriteAsync("Hello from the middleawre component.");
});

app.MapControllers();

app.Run();
