using AspNetUnityOfWork.Data;
using AspNetUnityOfWork.Data.Entities;
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

SeedData();

app.Run();

void ConfigureDatabase()
{
    builder.Services.AddDbContext<DataContext>(x =>
    {
        x.UseInMemoryDatabase(Guid.NewGuid().ToString());
    }, ServiceLifetime.Singleton);
}

void ConfigureRepositories()
{
    builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
    builder.Services.AddScoped<IBookRepository, BookRepository>();
    builder.Services.AddScoped<IUnityOfWorkRepository, UnityOfWorkRepository>();
}

void SeedData()
{
    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        var context = serviceProvider.GetRequiredService<DataContext>();

        context.Database.EnsureCreated();

        context.Authors.Add(new Author("Gilthayllor Sousa"));

        context.SaveChanges();
    }

}
