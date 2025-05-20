using Microsoft.EntityFrameworkCore;
using SampleAPI;
using SampleAPI.Services;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//add appication DB context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnections");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//register custom services
builder.Services.AddScoped<IStudentService, StudentService>();

// Configure CORS
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        builder => builder
            .WithOrigins("http://localhost:5173") // your Vite/Vue dev server
            .AllowAnyMethod()
            .AllowAnyHeader());
});


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
// Use CORS
app.UseCors("AllowVueApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
