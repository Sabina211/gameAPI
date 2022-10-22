using GameAPI.Application.Services;
using GameAPI.Domain.Repositories;
using GameAPI.Infrastructure;
using GameAPI.Infrastructure.Repositories;
using GameAPI.Web.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameAPI", Version = "v1" });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml");
    c.IncludeXmlComments(filePath);
});
builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("GameDb"),
        x => x.MigrationsAssembly("GameAPI.Infrastructure")));

/*builder.Services.AddDbContext<GameDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("GameDb"),
        x => x.MigrationsAssembly("GameAPI.Infrastructure"));
    options.EnableSensitiveDataLogging();
});*/

//builder.Services.AddScoped<DbContext, GameDbContext>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IDeveloperService, DeveloperService>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var s = scope.ServiceProvider;
    var c = s.GetRequiredService<GameDbContext>();
    CreateTestData.CreateData(c);
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
