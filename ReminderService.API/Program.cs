using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using ReminderService.API.Middlewares;
using ReminderService.Application;
using ReminderService.Application.Filters;
using ReminderService.Application.Validators;
using ReminderService.Infrastructure;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
}).Services.AddValidatorsFromAssemblyContaining<ReminderValidator>()
.AddFluentValidationAutoValidation()
.AddFluentValidationClientsideAdapters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddSingleton<SmtpClient>(x => new SmtpClient
{
    Host = builder?.Configuration?["Mail:Host"],
    Port = Convert.ToInt32(builder?.Configuration?["Mail:Port"]),
    EnableSsl = true,
    DeliveryMethod = SmtpDeliveryMethod.Network,
    UseDefaultCredentials = false,
    Credentials = new NetworkCredential(builder?.Configuration?["Mail:UserName"], builder?.Configuration?["Mail:Password"])
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseExceptionHandlerMiddleware(app.Services.GetRequiredService<ILogger<Program>>());
app.MapControllers();
app.Run();
