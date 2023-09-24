using Contract.Helpers;
using Domain.Repositories;
using Microsoft.OpenApi.Models;
using Persistence.Repository;
using Service;
using Services.Abstraction;
using Web.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" }));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IHelper, Helper>();


builder.Services.AddScoped<IDriverService, DriverService>();

builder.Services.AddScoped<IDriverRepository, DriverRepository>();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();


var app = builder.Build();

// ensure database and tables exist
{
    using var scope = app.Services.CreateScope();
    var repository = scope.ServiceProvider.GetRequiredService<IDriverRepository>();
    await repository.InitDrivertableAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
}

app.UseMiddleware<ExceptionHandlingMiddleware>();


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());


app.Run();
