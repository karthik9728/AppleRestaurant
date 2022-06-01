using Apple.Services.ShoppingCartAPI.Data;
using Apple.Services.ShoppingCartAPI.Mapping;
using Apple.Services.ShoppingCartAPI.Repository;
using Apple.Services.ShoppingCartAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Database Configuration

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

#endregion


#region Auto Mapper Configuration

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion


#region Repository Services

builder.Services.AddScoped<ICartRepository,CartRepository>();

#endregion


#region Authentication

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    //Url of Identity Server
    options.Authority = "https://localhost:7273/";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false
    };

});

#endregion


#region

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "apple");
    });
});

#endregion

//builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(
    x =>
    {
        x.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Apple.Services.ShoppingCartAPI" });
        x.EnableAnnotations();
        x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"Enter 'Bearer'[space] and your token",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });


        x.AddSecurityRequirement(new OpenApiSecurityRequirement(){
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>()
        }
        });
    }
 );



//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();