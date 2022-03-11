using Microsoft.EntityFrameworkCore;
using Tele2Api;
using WebApi;
using WebApi.BusinessLogic;
using WebApi.Core;
using WebApi.Core.Repositories;
using WebApi.DataAccess.MSSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ContractMapperProfile>();
    cfg.AddProfile<DataAccesseMappingProfile>();
});

builder.Services.AddScoped<IUsersRepositories, UsersRepositories>();
builder.Services.AddScoped<IUsersServices, UserServices>();

builder.Services.AddTele2ApiUsers(builder.Configuration);

builder.Services.AddDbContext<WebApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApi"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();
