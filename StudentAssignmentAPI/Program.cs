using Microsoft.EntityFrameworkCore;
using StudentAssignmentAPI.Data;
using StudentAssignmentAPI.Repositories;
using StudentAssignmentAPI.Repositories.Interfaces;
using StudentAssignmentAPI.Services;
using StudentAssignmentAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddDbContext<ApplicationDbContext>(b =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    b.UseNpgsql(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
