using Azure.Storage.Blobs;
using MediaAPI;
using MediaAPI.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var blobstring = builder.Configuration.GetConnectionString("blobString");
Console.WriteLine(blobstring.Substring(0,5));
var database = builder.Configuration.GetConnectionString("database");

builder.Services.AddDbContext<MultiMediaAppContext>(options => options.UseNpgsql(database));
builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.AddScoped<MultiMediaAppContext>();


builder.Services.AddSingleton(x => new BlobServiceClient(blobstring));
BlobServiceClient blobServiceClient = new(blobstring);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
