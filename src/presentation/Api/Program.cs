using Api.BackgroundServices;
using Api.Commons;
using DependencyResolver;
using Infrastructure.Commons;

const string _corsPolicy = "EnableAll";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<ConfigurationOptions>(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.RegisterDependencies(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ApiMappingProfile));

// builder.Services.Configure<HostOptions>(hostOptions =>
//         {
//             hostOptions.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
//         })
//     .AddHostedService<KafkaConsumerHostedService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _corsPolicy,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
