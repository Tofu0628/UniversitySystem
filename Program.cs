global using UniSys.Models;
global using UniSys.Data;

using Microsoft.EntityFrameworkCore;
using UniSys.Service;
using UniSys.Repository;
using UniSys.Service.Interface;
using UniSys.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UniSysContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniSysContext") ?? throw new InvalidOperationException("Connection string 'UniSysContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add service & repository
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<IEnrollmentsService, EnrollmentsService>();
builder.Services.AddScoped<IEnrollmentsRepository, EnrollmentsRepository>();
builder.Services.AddScoped<IExamResultsService, ExamResultsService>();
builder.Services.AddScoped<IExamResultsRepository, ExamResultsRepository>();
builder.Services.AddScoped<ISubjectsService, SubjectsService>();
builder.Services.AddScoped<ISubjectsRepository, SubjectsRepository>();
builder.Services.AddScoped<ITutorsService, TutorsService>();
builder.Services.AddScoped<ITutorsRepository, TutorsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
