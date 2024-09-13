using Tree.API.Extensions;
using Tree.API.MIddlewares;
using Tree.Application.Extensions;
using Tree.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddOptionsSetups();

builder.Services
    .AddPersistence()
    .AddApplication();

builder.Services
    .AddEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var apiGroup = app.MapGroup(Tree.API.Constants.Application.ApiGroup);

app.MapEndpoints(apiGroup);

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.Run();