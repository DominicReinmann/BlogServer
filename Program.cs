using BlogServer.Authentication;
using BlogServer.StartUp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Injection 
var inject = new DependencyInjection(builder);
inject.Inject();

// Auth 
var auth = new JwtAuthentication(builder);
auth.Authenticate();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
