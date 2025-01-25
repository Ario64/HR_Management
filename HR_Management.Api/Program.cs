using HR_Management.Application;
using HR_Management.Infrastructure;
using HR_Management.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

#region DI Configuration

builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Policy Configuration

builder.Services.AddCors(p =>
{
    p.AddPolicy("CorsPolicy", b =>
    {
        b.AllowAnyHeader();
        b.AllowAnyMethod();
        b.AllowAnyOrigin();
    });
});

#endregion

#region Logging Using Serilog

Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq("http://localhost:5258")
    .MinimumLevel.Warning()
    .CreateLogger();

builder.Host.UseSerilog();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
