using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MonitoNet.Backend.Infrastructure.Mongo;
using MonitoNet.Backend.Infrastructure.Persistence.Mongo.Repositories;
using MonitoNet.Backend.Iam.Application.CommandServices;
using MonitoNet.Backend.Iam.Application.Internal.CommandServices;
using MonitoNet.Backend.Iam.Application.Internal.QueryServices;
using MonitoNet.Backend.Iam.Application.QueryServices;
using MonitoNet.Backend.Iam.Domain.Repositories;
using MonitoNet.Backend.Social.Application.CommandServices;
using MonitoNet.Backend.Social.Application.Internal.CommandServices;
using MonitoNet.Backend.Social.Application.Internal.QueryServices;
using MonitoNet.Backend.Social.Application.QueryServices;
using MonitoNet.Backend.Social.Domain.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection(MongoDbSettings.SectionName));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();

builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<IPublicationQueryService, PublicationQueryService>();
builder.Services.AddScoped<INotificationQueryService, NotificationQueryService>();
builder.Services.AddScoped<INotificationCommandService, NotificationCommandService>();
builder.Services.AddScoped<IPublicationCommandService, PublicationCommandService>();
builder.Services.AddScoped<ICommentCommandService, CommentCommandService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
