using BusTrack_center_API.Notifications.Domain.Repositories;
using BusTrack_center_API.Notifications.Domain.Services;
using BusTrack_center_API.Notifications.Infrastructure.Persistence.EFC.Repositories;
using BusTrack_center_API.Notifications.Application.Internal.CommandServices;
using BusTrack_center_API.Notifications.Application.Internal.QueryServices;
using BusTrack_center_API.Shared.Domain.Repositories;
using BusTrack_center_API.Shared.Infrastructure.Persistence.EFC;
using BusTrack_center_API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("BusTrackDb"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "BusTrack API",
            Version = "v1",
            Description = "BusTrack backend API for routes, notifications and user features"
        });
});



// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Notifications BC
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationCommandService, NotificationCommandService>();
builder.Services.AddScoped<INotificationQueryService, NotificationQueryService>();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
