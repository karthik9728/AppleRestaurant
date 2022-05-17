using Apple.Services.ProductAPI.Data;
using Apple.Services.ProductAPI.Mapping;
using Apple.Services.ProductAPI.Repository;
using Apple.Services.ProductAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


#region Database Configuration

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connectionString));

#endregion


#region Auto Mapper Configuration

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion


#region Repository Services

builder.Services.AddScoped<IProductRepository, ProductRepository>();

#endregion

builder.Services.AddSwaggerGen();

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
