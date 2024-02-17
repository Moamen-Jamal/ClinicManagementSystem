using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FluentValidation.AspNetCore;
using ClinicManagement.Application;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(EntitiesContext));
builder.Services.AddDbContext<EntitiesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicManagementConnection")));


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register the CustomLogger class
builder.Services.AddSingleton<CustomLogger>();

//Configure AutoMapper && MediatR && Fluient Validation
builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}


//Add support to logging with SERILOG

Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
builder.Host.UseSerilog(Log.Logger);

//Mapster Configuration
builder.Services.RegisterMapsterConfiguration();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/uploads"
});

//Add support to logging request with SERILOG
app.UseSerilogRequestLogging();
app.UseRouting();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
