using Application;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<JiraDbContext>(opt=>{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddPersistenceService();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(ApplicationAssembly.Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
