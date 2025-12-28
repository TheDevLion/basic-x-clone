using System.Reflection;
using BasicXCloneBackend.Application.Interfaces;
using BasicXCloneBackend.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BasicXCloneBackend.Domain.Interfaces;
using BasicXCloneBackend.Infrastructure;
using BasicXCloneBackend.Infrastructure.Repositories;
using BasicXCloneBackend.BasicXCloneAPI.SwaggerExamples;
using Swashbuckle.AspNetCore.Filters;
using BasicXCloneBackend.Application.Mapping;
using BasicXCloneBackend.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Missing connection string. Set ConnectionStrings__DefaultConnection in environment variables.");
}

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString,
        b => b.MigrationsAssembly("BasicXCloneAPI")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IRepostRepository, RepostRepository>();
builder.Services.AddScoped<IRepostService, RepostService>();
builder.Services.AddScoped<IHelperRepository, HelperRepository>();
builder.Services.AddScoped<IHelperService, HelperService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);



builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "basic-x-clone API", Version = "v1" });

    c.EnableAnnotations();
    c.ExampleFilters();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<CreateNewPostRequestExample>();


builder.Services.AddCors(options =>
{
    var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
        ?? new[] { "http://localhost:5173" };

    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "basic-x-clone API v1");
    });
}
else
{
    app.UseHsts();
}


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseRouting();

app.UseMiddleware<UserVerificationMiddleware>();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();

    if (!dbContext.User.Any())
    {
        dbContext.User.AddRange(
            new User { UserName = "rodrigoczleo" },
            new User { UserName = "gabrielamatias" },
            new User { UserName = "johntextor" },
            new User { UserName = "neymarjr" }
        );
        dbContext.SaveChanges();
    }
}

app.Run();

