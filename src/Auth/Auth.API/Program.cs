using Auth.API.Extensions;
using Shared.Infrastructure.Extensions;
using Shared.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                               .AddJsonFile("appsettings.json")
                               .Build();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddManagementDbContext();
builder.Services.RegisterManagementServices();
builder.Services.RegisterSharedServices();
builder.Services.AddJWTAuthentication(configuration);

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

app.UseMiddleware<JwtMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
