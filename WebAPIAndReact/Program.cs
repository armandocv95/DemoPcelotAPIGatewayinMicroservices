using WebAPIAndReact.Data;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();

    var courses = await dbContext.Courses
            .Include(c => c.CourseTeachers) // Incluir la relación de CourseTeacher
            .ThenInclude(ct => ct.Teacher) // Incluir los maestros a través de CourseTeacher
            .ToListAsync();


    foreach (var course in courses)
    {
        Console.WriteLine($"CourseId: {course.CourseId}, Title: {course.Title}, Date: {course.DatePublish}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherForecast");
        c.RoutePrefix = "";  // Opens Swagger at root URL
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<RestrictAccesMiddleware>();
app.MapControllers();

app.Run();
