using AspNetUnityOfWork.Data;
using AspNetUnityOfWork.Data.Repositories.Implementations;
using AspNetUnityOfWork.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureDatabase();
ConfigureRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();

void ConfigureDatabase()
{
    builder.Services.AddDbContext<DataContext>(x =>
    {
        x.UseInMemoryDatabase("UoWDatabase");
    });
}

void ConfigureRepositories()
{
    builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
    builder.Services.AddScoped<IBookRepository, BookRepository>();
    builder.Services.AddScoped<IUnityOfWorkRepository, UnityOfWorkRepository>();
}
