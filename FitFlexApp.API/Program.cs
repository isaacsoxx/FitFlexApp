using FitFlexApp.BLL.Services;
using FitFlexApp.BLL.Services.Interface;
using FitFlexApp.DAL.Context;
using FitFlexApp.DAL.Repository;
using FitFlexApp.DAL.Repository.Interface;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/info.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true)
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

/* Automapper persistance */
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/* Services persistance */
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

/* Repository persistance */
builder.Services.AddScoped<IFitFlexAppRepository, FitFlexAppRepository>();

/* EF persistence on sqlserver */
builder.Services.AddDbContext<FitFlexAppContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("FitFlexDB_MSSQL"));
    options.EnableSensitiveDataLogging();
});

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(end =>
{
    end.MapControllers();
});

app.Run();
